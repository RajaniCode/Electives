using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace SL4_DataGrid_Custom_Command_Behavior
{
    public class DataGridCustomCommandBehavior : CommandBehaviorBase<DataGrid>
    {
        public DataGridCustomCommandBehavior(DataGrid dataGrid): base(dataGrid)
        {
            dataGrid.RowEditEnded += OnRowEditCompleted; 
        }

        private void OnRowEditCompleted(object s, DataGridRowEditEndedEventArgs e)
        {
            this.ExecuteCommand(); 
        }
    }

    public class RowEditEnded
    {

        public static object GetCommandParameter(DependencyObject obj)
        {
            return (object)obj.GetValue(CommandParameterProperty);
        }

        public static void SetCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(CommandParameterProperty, value);
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(RowEditEnded), 
            new PropertyMetadata(OnSetCommandParameterCallback));



        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }

        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(RowEditEnded),
            new PropertyMetadata(OnSetCommandCallback));



        public static DataGridCustomCommandBehavior GetClickCommandBehavior(DependencyObject obj)
        {
            return (DataGridCustomCommandBehavior)obj.GetValue(ClickCommandBehaviorProperty);
        }

        public static void SetClickCommandBehavior(DependencyObject obj, DataGridCustomCommandBehavior value)
        {
            obj.SetValue(ClickCommandBehaviorProperty, value);
        }

        // Using a DependencyProperty as the backing store for ClickCommandBehavior.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClickCommandBehaviorProperty =
            DependencyProperty.RegisterAttached("ClickCommandBehavior", typeof(DataGridCustomCommandBehavior), typeof(RowEditEnded), null);


        private static DataGridCustomCommandBehavior GetOrCreateDataGridBehavior(DataGrid dataGrid)
        {
            var dgBehavior = dataGrid.GetValue(ClickCommandBehaviorProperty) as DataGridCustomCommandBehavior;
            if (dgBehavior == null)
            {
                dgBehavior = new DataGridCustomCommandBehavior(dataGrid);
                dataGrid.SetValue(ClickCommandBehaviorProperty, dgBehavior); 
            }
            return dgBehavior;
        }

        private static void OnSetCommandCallback(DependencyObject dep, DependencyPropertyChangedEventArgs e)
        {
            var dataGrid = dep as DataGrid;
            if (dataGrid != null)
            {
                DataGridCustomCommandBehavior behavior = GetOrCreateDataGridBehavior(dataGrid);
                behavior.Command = e.NewValue as ICommand;
            }
        }

        private static void OnSetCommandParameterCallback(DependencyObject dep,
            DependencyPropertyChangedEventArgs e)
        {
            var dataGrid = dep as DataGrid;
            if (dataGrid != null)
            {
                DataGridCustomCommandBehavior behavior = GetOrCreateDataGridBehavior(dataGrid); ;
                behavior.CommandParameter = e.NewValue;
            }
        }
        
    }
}
