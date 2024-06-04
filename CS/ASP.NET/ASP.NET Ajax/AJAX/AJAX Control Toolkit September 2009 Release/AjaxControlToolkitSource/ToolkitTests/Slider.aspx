<%@ Page Language="C#" 
         AutoEventWireup="true" 
         CodeFile="Slider.aspx.cs" 
         Inherits="Slider"
         MasterPageFile="~/Default.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table>
        <tr>
            <td>
                <asp:TextBox ID="slider1" runat="server"></asp:TextBox>
                <asp:TextBox ID="slider2" runat="server"></asp:TextBox>
                <asp:TextBox ID="slider3" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="slider1_boundControl" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnPostBack" runat="server" Text="Postback" />
            </td>
        </tr>
    </table>
    
    <ajaxToolkit:SliderExtender ID="SliderExtender1" runat="server"
                                TargetControlID="slider1"
                                BoundControlID="slider1_boundControl"
                                Decimals="0"
                                />
                                
    <ajaxToolkit:SliderExtender ID="SliderExtender2" runat="server"
                                TargetControlID="slider2"
                                Maximum="100" Minimum="-100" Steps="5"
                                Decimals="0"
                                />
                                
    <ajaxToolkit:SliderExtender ID="SliderExtender3" runat="server"
                                TargetControlID="slider2"
                                Maximum="1" Minimum="0.1" Steps="10"
                                Decimals="2" Orientation="Vertical"
                                />
    
    <script type="text/javascript">
        // (c) Copyright Microsoft Corporation.
        // This source is subject to the Microsoft Public License.
        // See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
        // All other rights reserved.
    
        // Script objects that should be loaded before we run
        var typeDependencies = ['AjaxControlToolkit.SliderBehavior'];
    
        // Test Harness
        var testHarness = null;

        // Controls in the page
        var slider1 = null;
        var slider2 = null;
        var slider3 = null;
        var slider1_boundControl = null;
        var btn = null;

        function checkInitialized(slider) {
            return function() {
                return slider.get_SliderInitialized();
            }
        }
          
        function checkMinimum() {
            testHarness.assertEqual(slider1.get_Value(), slider1.get_Minimum(), 
                'The value of the slider should be ' + slider1.get_Minimum() + ' instead of ' + slider1.get_Value());
        }
        
        function checkMaximum() {
            testHarness.assertEqual(slider1.get_Value(), slider1.get_Maximum(), 
                'The value of the slider should be ' + slider1.get_Minimum() + ' instead of ' + slider1.get_Value());
        }
        
        function checkTextBox() {
            testHarness.assertEqual(slider1.get_Value(), parseFloat(slider1.get_element().value), 
                'The value in the textbox should be ' + slider1.get_Value() + ' instead of ' + slider1.get_element().value);
        }
        
        function checkBoundControl() {
            testHarness.assertEqual(slider1.get_Value(), parseFloat(slider1_boundControl.value), 
                'The value in the bound control should be ' + slider1.get_Value() + ' instead of ' + slider1_boundControl.value);
        }
                
        function setValueFromBoundControl(value) {
            return function() {
                slider1_boundControl.value = value;
                testHarness.fireEvent(slider1_boundControl, 'onchange'); 
            };
        }
        
        // Test the initial state of the control
        function testInitialState() {
            checkMinimum();
            checkTextBox();
            checkBoundControl();
        }
        
        function testValueFromSlider(value) {
            return function() {
                slider1.set_Value(value);
                checkTextBox();
                checkBoundControl();
            };
        }
        
        function testValueAfterPostBack(value) {
            return function() {
                testHarness.assertEqual(slider1.get_Value(), value, 'Value after postback should be ' + value + ' instead of ' + slider1.get_Value());
            }
        }

        function setSliderValue(slider, value) {
            return function() {
                slider.set_Value(value);
            }
        }

        function testSliderValue(slider, value) {
            return function() {
                testHarness.assertEqual(slider.get_Value(), value, 'Value should be ' + value + ' instead of ' + slider.get_Value());
            }
        }

        function initializeEvent(element, eventName, charCode, keyCode) {
            var eventObject;
            if (document.createEventObject) {
                var eventObject = document.createEventObject();
                eventObject.srcElement = element;
                eventObject.type = eventName;
                if (keyCode) {
                    eventObject.keyCode = keyCode;
                }
                if (charCode) {
                    eventObject.charCode = charCode;
                }
            } else if (document.createEvent) {
                var eventObject = document.createEvent('KeyEvents');
                eventObject.initKeyEvent(eventName, true, true, null, false, false, false, false, keyCode, charCode);
            } else {
                alert("Can't create fire events using this browser");
                return null;
            }

            return new Sys.UI.DomEvent(eventObject);
        }

        function sendKey(slider, keyCode) {
            return function() {
                slider._onKeyDown(initializeEvent(slider._railElement, 'keydown', null, keyCode));
            }
        }

        // Register the tests
        function registerTests(harness) {
            testHarness = harness;

            // Get the controls from the page
            slider1 = testHarness.getObject('ctl00_ContentPlaceHolder1_SliderExtender1');
            slider1_boundControl = testHarness.getElement('ctl00_ContentPlaceHolder1_slider1_boundControl');
            slider2 = testHarness.getObject('ctl00_ContentPlaceHolder1_SliderExtender2');
            slider3 = testHarness.getObject('ctl00_ContentPlaceHolder1_SliderExtender3');
            btn = testHarness.getElement('ctl00_ContentPlaceHolder1_btnPostBack');

            // Initial state of the control.
            var test = testHarness.addTest('Initial');
            test.addStep(Function.emptyMethod, checkInitialized(slider1));
            test.addStep(testInitialState);

            // Set a value from the slider control.
            test = testHarness.addTest('Set value from Slider');
            test.addStep(Function.emptyMethod, checkInitialized(slider1));
            test.addStep(testValueFromSlider(80));
            test.addStep(testValueFromSlider(25));

            // Set some values outside the allowed range.
            test = testHarness.addTest('Out of bound values');
            test.addStep(Function.emptyMethod, checkInitialized(slider1));
            test.addStep(testValueFromSlider(-25));
            test.addStep(testValueFromSlider(250));

            // Check if a value set on the slider is persisted after a postback.
            test = testHarness.addTest('Value persisted after PostBack');
            test.addStep(Function.emptyMethod, checkInitialized(slider1));
            test.addStep(testValueFromSlider(80));
            test.addPostBack(btn);
            test.addStep(Function.emptyMethod, checkInitialized(slider1));
            test.addStep(testValueAfterPostBack(80));

            // Set the slider's value through the bound control.
            test = testHarness.addTest('Set value from bound control');
            test.addStep(Function.emptyMethod, checkInitialized(slider1));
            test.addStep(setValueFromBoundControl(80));
            test.addStep(checkTextBox);
            test.addStep(checkBoundControl);

            // Set some values outside the allowed range through the bound control.
            test = testHarness.addTest('Out of range values from bound control');
            test.addStep(Function.emptyMethod, checkInitialized(slider1));
            test.addStep(setValueFromBoundControl(-25.123));
            test.addStep(checkMinimum);
            test.addStep(checkTextBox);
            test.addStep(checkBoundControl);
            test.addStep(setValueFromBoundControl(250.456));
            test.addStep(checkMaximum);
            test.addStep(checkTextBox);
            test.addStep(checkBoundControl);

            // Set an invalid value (not a number) through the bound control.
            test = testHarness.addTest('Invalid value in bound control');
            test.addStep(Function.emptyMethod, checkInitialized(slider1));
            test.addStep(setValueFromBoundControl('invalid value'));
            test.addStep(checkMinimum);
            test.addStep(checkTextBox);
            test.addStep(checkBoundControl);

            if (Sys.Browser.agent == Sys.Browser.InternetExplorer || Sys.Browser.agent == Sys.Browser.Firefox) {
                // Test keyboard navigation - Horizontal
                test = testHarness.addTest('Keyboard navigation - Horizontal');
                test.addStep(Function.emptyMethod, checkInitialized(slider2));
                test.addStep(setSliderValue(slider2, 50));
                test.addStep(testSliderValue(slider2, 50));
                test.addStep(sendKey(slider2, Sys.UI.Key.right));
                test.addStep(testSliderValue(slider2, 100));
                test.addStep(sendKey(slider2, Sys.UI.Key.right));
                test.addStep(testSliderValue(slider2, 100));
                test.addStep(sendKey(slider2, Sys.UI.Key.left));
                test.addStep(testSliderValue(slider2, 50));
                test.addStep(sendKey(slider2, Sys.UI.Key.left));
                test.addStep(testSliderValue(slider2, 0));
                test.addStep(sendKey(slider2, Sys.UI.Key.left));
                test.addStep(testSliderValue(slider2, -50));
                test.addStep(sendKey(slider2, Sys.UI.Key.left));
                test.addStep(testSliderValue(slider2, -100));
                test.addStep(sendKey(slider2, Sys.UI.Key.left));
                test.addStep(testSliderValue(slider2, -100));

                // Test keyboard navigation - Vertical
                test = testHarness.addTest('Keyboard navigation - Vertical');
                test.addStep(Function.emptyMethod, checkInitialized(slider3));
                test.addStep(setSliderValue(slider3, 0.5));
                test.addStep(testSliderValue(slider3, 0.5));
                test.addStep(sendKey(slider3, Sys.UI.Key.down));
                test.addStep(testSliderValue(slider3, 0.6));
                test.addStep(sendKey(slider3, Sys.UI.Key.down));
                test.addStep(testSliderValue(slider3, 0.7));
                test.addStep(sendKey(slider3, Sys.UI.Key.down));
                test.addStep(sendKey(slider3, Sys.UI.Key.down));
                test.addStep(sendKey(slider3, Sys.UI.Key.down));
                test.addStep(sendKey(slider3, Sys.UI.Key.down));
                test.addStep(sendKey(slider3, Sys.UI.Key.down));
                test.addStep(testSliderValue(slider3, 1));
                test.addStep(sendKey(slider3, Sys.UI.Key.up));
                test.addStep(sendKey(slider3, Sys.UI.Key.up));
                test.addStep(sendKey(slider3, Sys.UI.Key.up));
                test.addStep(sendKey(slider3, Sys.UI.Key.up));
                test.addStep(sendKey(slider3, Sys.UI.Key.up));
                test.addStep(sendKey(slider3, Sys.UI.Key.up));
                test.addStep(testSliderValue(slider3, 0.4));
            }
        }
    </script>
    
</asp:Content>
