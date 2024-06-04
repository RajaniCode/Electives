<?xml version="1.0"?>
<!--

  xdr-xsd-converter.xslt 1.5
  
  XSLT Style sheet for transforming XML Data Reduced (XDR) schemas to
  compliant W3C XML Schema Recommendation (May 2, 2001).  This tool
  currently requires the msxsl:node-set() extension function and 
  therefore requires the use of Microsoft MSXML 3.0 or later, which can 
  be downloaded at http://msdn.microsoft.com/xml.
  
  1.0.1: (5 Oct 2000)
    Changed RTF queries to msxsl:node-set().
    Added exclude-result-prefixes to support validation of the results.
    Changed output DTD to official version (XMLSchemas.dtd/part2.dtd)
  
  1.1: (10 Oct 2000)
    Major rewrite to update to Sept 22 XSD draft.
    Fixed a bunch of bugs discovered in the process.

  1.2: (25 Oct 2000)
    Produces output valid against Oct 24 CR XSD draft.
    Minor cleanup of source (generate XML decl, PUBLIC id, better
      modularization, regluarization of named templates, etc.)
    Preservation of most comments in the source.
    Bug fixes
      - UUID pattern now allows lowercase
      - enums derived from xs:NMTOKEN (had NMTOKENS in one place)
      - elements with enums and attributes fixed
      - elements with length constraints and attributes fixed
    
  1.3: (16 Mar 2001)
    Produces output valid against Mar 16 XSD PR DTDs.
    Namespace change.
    Prefix change - eliminates internal subset.
    use/value ==> use/default/fixed.
    Simple datatype name and definition changes.

  1.4: (18 Apr 2001)
    Bug fix: missing minOccurs="0" attribute on mixed content models.
    Bug fix: removed duplicate handling of some date/time datatypes.
    Bug fix: more precise datatypes for date, dateTime, time (no time zones)

  1.5: (15 Oct 2001)
    Improvements by Andrei Maksimenka <andreim@microsoft.com> which take
    advantage of XML Schema defaults and shortcuts, including:
    - suppressing minOccurs and maxOccurs attributes with the value of "1" 
      (the default).
    - suppressing empty <xs:sequence> and <xs:choice> elements
    - suppressing nested <xs:choice minOccurs="0" maxOccurs="unbounded"> for
      mixed content
    - shortening declaration of element with @content='empty' by removing 
        <xs:complexContent>
          <xs:restriction base="xs:anyType">
            ...
          </xs:restriction>
        </xs:complexContent> 
      as illustrated in section http://www.w3.org/TR/xmlschema-0/#emptyContent
    - copy attribute annotations (non-schema namespace) on xdr:Schema, 
      xdr:ElementType, xdr:AttributeType, xdr:group, xdr:element, and 
      xdr:attribute elements to the corresponding XML Schema element.
    - improved importability with extension element template.
    - improved importability with named template for datatype definitions.
    - more reliable support for embedded schemas - tosses any wrapper elements.
    
    Bug fix: suppressed occurances of empty attributes fixed="" and default="".
    Bug fix: changed occurances of xs:number to xs:float, and added
      translation of minLength and maxLength into a pattern.
      
  1.6: (18 Nov 2003)
	Improvements and bug fixes by Andrei Maksimenka <andreim@microsoft.com> which:
	- enumeration of elements and attributes instead of any nodes when mode="extension-elements".
	- updated pattern for dt:time data type to include optional seconds and their fractions.
	- do not generate <xs:any namespace="##targetNamespace" /> when content model is open to avoid
	  non deterministic state in XSD schema.
	- suppress of minLength and maxLength restrictive facets for dt:number data type because it's
	  expressed using xs:float data type which doesn't support those facets.
	- fixed bug when dt:type was erroneously selected as element, not an attribute in template 
	  matching xdr:ElementType.
	- reworked handling of order 'many' and default ordering, which is 'seq' when order is not specified
	  and when content model is 'eltOnly'.
	- added handling of the annotations also from xdr:ElementType declarations, if they are missing for the
	  corresponding xdr:element.
	- explicitly stamp use="optional" when required="no" appears for the XDR attribute.
  
  1.7 (02 Dec 2003)
    Changed generation of global elements to complexTypes by John Taylor <johtaylo@microsoft.com>
    - these changes are specific to the XDR generated from SQLXML
    - ElementTypes are now mapped to complexTypes
    - complexType name has 'Type' concatenated to the name
    - within a complexType definition elements refer to the name and type rather than the ref
    - ElementTypes with simple content generate complexTypes with simpleContent and an extension 
    
  Author: Jonathan Marsh <jmarsh@microsoft.com>
  Copyright 2000 Microsoft Corp.
  
-->

<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:xs="http://www.w3.org/2001/XMLSchema"
                xmlns:xdr = "urn:schemas-microsoft-com:xml-data"
                xmlns:dt = "urn:schemas-microsoft-com:datatypes"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                exclude-result-prefixes="xdr dt msxsl">

<xsl:output method="xml" omit-xml-declaration="no" indent="yes" />

<xsl:template match="node()"/>

<xsl:template match="comment()">
  <xsl:copy-of select="."/>
</xsl:template>

<!-- override this template to suppress or apply transformations to 
     extension elements -->
<xsl:template match="@* | node()" mode="extension-elements">
  <xsl:copy-of select="."/>
</xsl:template>

<!-- main document conversion template -->

<xsl:template match="/">

<!-- Note that all comments generated by this stylesheet are preceded
     by "[XDR-XSD]" to distinguish them from comments passed through
     from the source XDR. -->
<xsl:comment>
  [XDR-XSD] This schema automatically updated from an IE5-compatible XDR schema to W3C
  XML Schema by xdr-xsd-converter.xslt 1.5, available from Microsoft.
  See http://msdn.microsoft.com/xml.

  Note: if a local copy of XMLSchema.dtd and datatypes.dtd are not
  available, use the official location of "http://www.w3.org/2000/10/XMLSchema.dtd"
  for the system id.
</xsl:comment>

  <xsl:apply-templates select="//xdr:Schema[1]"/>

</xsl:template>

<xsl:template match="xdr:Schema">
<xs:schema version="1.0">
  
  <!-- discover references to external elements -->
  <xsl:variable name="prefixes">
    <xsl:for-each select=".//xdr:attribute[contains(@type,':')] | .//xdr:element[contains(@type,':')]">
      <prefix><xsl:value-of select="substring-before(@type,':')"/></prefix>
    </xsl:for-each>
  </xsl:variable>
  
  <!-- sort the prefixes, in preparation for eliminating duplicates -->
  <xsl:variable name="sorted-prefixes">
    <xsl:for-each select="msxsl:node-set($prefixes)/prefix">
      <xsl:sort select="."/>
      <xsl:copy-of select="."/>
    </xsl:for-each>
  </xsl:variable>
  
  <!-- eliminate duplicaates -->
  <xsl:variable name="unique-prefixes">
    <xsl:for-each select="msxsl:node-set($sorted-prefixes)/prefix">
      <xsl:variable name="here" select="position()"/>
      <xsl:if test="$here=1 or ../prefix[position() &lt; $here][1] != .">
         <xsl:copy-of select="."/>
      </xsl:if>
    </xsl:for-each>
  </xsl:variable>
  
  <!-- make namespace declarations for any external schemas -->
  <xsl:variable name="root" select="/"/>
  <xsl:variable name="namespaces">
    <dummy>
      <xsl:for-each select="msxsl:node-set($unique-prefixes)/prefix">
        <xsl:attribute name="{.}:dummy" namespace="namespace-uri($root//namespace::*[name()=current()][1])"/>
      </xsl:for-each>
    </dummy>
  </xsl:variable>

  <xsl:copy-of select="msxsl:node-set($namespaces)/namespace::*"/>

  <xsl:call-template name="attribute-annotations"/>

  <!-- make import statements for any external schemas -->
  <xsl:for-each select="msxsl:node-set($unique-prefixes)/prefix">
    <xsl:variable name="ns" select="concat('xmlns:',current())"/>
    <xsl:variable name="ns-uri" select="$root//@*[name()=$ns]"/>
    <xs:import namespace="{$ns-uri}" schemaLocation="{substring-after($ns-uri,'x-schema:')}"/>
  </xsl:for-each>
          
  <xsl:call-template name="annotations">
    <xsl:with-param name="documentation-extras">
      <xsl:if test="@name">Schema name: <xsl:value-of select="@name"/></xsl:if>
    </xsl:with-param>
  </xsl:call-template>
  
  <xsl:apply-templates select="node()">
    <xsl:sort select="not(self::xdr:description)"/>
  </xsl:apply-templates>

  <xsl:call-template name="datatype-definitions"/>

</xs:schema>
</xsl:template>

<!-- Library of named templates -->

<xsl:template name="datatype-definitions">
  <!-- Some XDR datatypes don't have direct equivalents in XSD.
       If any of these types are used, place a datatype derivation
       in the result. -->
  <xsl:comment> [XDR-XSD] XDR datatype derivations </xsl:comment>
  
  <xsl:if test="//@dt:type='char'">
  <xs:simpleType name="char">
    <xs:restriction base="xs:string">
      <xs:length value="1"/>
    </xs:restriction>
  </xs:simpleType>        
  </xsl:if>
   
  <xsl:if test="//@dt:type='date'">
  <xs:simpleType name="date">
    <xs:restriction base="xs:date">
      <xs:pattern value="\d*-\d\d-\d\d"/>
    </xs:restriction>
    <!---CCYY-MM-DD Note no time zone. -->
  </xs:simpleType>
  </xsl:if>
  
<!--
  <xsl:if test="//@dt:type='dateTime'">
  <xs:simpleType name="dateTime">
    <xs:restriction base="xs:dateTime">
      <xs:pattern value="\d*-\d\d-\d\dT\d\d:\d\d(:\d\d(\.\d{{0,9}})?)?"/>
    </xs:restriction>
  </xs:simpleType>
  </xsl:if>
-->
  
<!--
  <xsl:if test="//@dt:type='fixed.14.4'">
  <xs:simpleType name="fixed.14.4">
    <xs:restriction base="xs:decimal">
      <xs:fractionDigits value="4"/>
      <xs:minInclusive value="-922337203685477.5808"/>
      <xs:maxInclusive value="922337203685477.5807"/>
    </xs:restriction>
  </xs:simpleType>
  </xsl:if>
-->

<!--  
  <xsl:if test="//@dt:type='r4'">
  <xs:simpleType name="r4">
    <xs:restriction base="xs:float">
      <xs:minInclusive value="-3.40282347E+38" />
      <xs:maxInclusive value="3.40282347E+38" />
    </xs:restriction>
  </xs:simpleType>
  </xsl:if>
-->

<!--
  <xsl:if test="//@dt:type='time'">
  <xs:simpleType name="time">
    <xs:restriction base="xs:time">
      <xs:pattern value="\d\d:\d\d(:\d\d(\.(\d)+)?)?"/>
    </xs:restriction>
  </xs:simpleType>
  </xsl:if>
-->

<!--
  <xsl:if test="//@dt:type='uuid'">
  <xs:simpleType name="uuid">
    <xs:restriction base="xs:string">
      <xs:pattern value="[0-9A-Fa-f]{{8}}\-?[0-9A-Fa-f]{{4}}\-?[0-9A-Fa-f]{{4}}\-?[0-9A-Fa-f]{{4}}\-?[0-9A-Fa-f]{{12}}"/>
    </xs:restriction>
  </xs:simpleType>
  </xsl:if>
-->

</xsl:template>

<xsl:template name="element-content">
  <xsl:apply-templates select="xdr:element | xdr:group | comment()"/>
</xsl:template>

<xsl:template name="attribute-content">
  <xsl:apply-templates select="node()[not(self::xdr:element or self::xdr:group or self::xdr:description or self::xdr:datatype)]"/>
</xsl:template>

<xsl:template name="attribute-annotations">
  <xsl:for-each select="@*[namespace-uri()!='' and namespace-uri()!='urn:schemas-microsoft-com:datatypes']">
    <xsl:copy/>
  </xsl:for-each>
</xsl:template>

<xsl:template name="annotations">
  <xsl:param name="documentation-extras"/>
  <xsl:param name="appinfo-extras"/>

  <xsl:if test="$documentation-extras or xdr:description or *[not(self::xdr:*)]">
    <xs:annotation>
      <xsl:for-each select="xdr:description">
        <xs:documentation><xsl:copy-of select="node()"/></xs:documentation>
      </xsl:for-each>
      <xsl:if test="$documentation-extras">
        <xs:documentation><xsl:copy-of select="$documentation-extras"/></xs:documentation>
      </xsl:if>
      <xsl:for-each select="*[not(self::xdr:*)]">
        <xs:appinfo><xsl:apply-templates select="." mode="extension-elements"/></xs:appinfo>
      </xsl:for-each>
      <xsl:if test="$appinfo-extras">
        <xs:appinfo><xsl:copy-of select="$appinfo-extras"/></xs:appinfo>
      </xsl:if>
    </xs:annotation>
  </xsl:if>    
</xsl:template>

<xsl:template name="any">
  <xsl:if test="not(@model='closed')">
    <xs:choice minOccurs="0" maxOccurs="unbounded">
      <xs:any namespace="##other" processContents="lax"/>
      <!-- DO NOT USE instruction below because it causes non-deterministic state in schema when located within
      elements which minOccurs="0" -->
      <!-- <xs:any namespace="##targetNamespace"/> -->
    </xs:choice>
  </xsl:if>
</xsl:template>

<xsl:template name="any-attribute">
  <xsl:if test="not(@model='closed')">
    <xs:anyAttribute namespace="##other" processContents="lax"/>
<!-- BUGBUG, can't express this in XSD, as only one anyAttribute is allowed.
    <xs:anyAttribute namespace="##targetNamespace"/>
-->
  </xsl:if>
</xsl:template>

<xsl:template name="simpleType-with-length">
  <!-- expects the context to be an xdr:ElementType -->
  <xsl:param name="name"/>
  <xsl:variable name="e" select="(. | xdr:datatype)[last()]"/>
  <xs:simpleType>
    <xsl:if test="$name">
      <xsl:attribute name="name"><xsl:value-of select="$name"/></xsl:attribute>
    </xsl:if>
    <xs:restriction>
      <xsl:attribute name="base">
        <xsl:choose>
          <xsl:when test="$e/@dt:type">
            <xsl:apply-templates select="$e/@dt:type" mode="convert-datatype"/>
          </xsl:when>
          <xsl:otherwise>xs:string</xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>
      <xsl:choose>
        <!-- suppress minLength and maxLength for d:number as it will be represented as xs:float which doesn't support
        minLength and maxLength facets -->
        <xsl:when test="$e/@dt:type='number'" />
        <xsl:when test="$e/@dt:minLength = $e/@dt:maxLength">
          <!-- A little optimization - generate "length" when min and max are equal -->
          <xs:length value="{$e/@dt:minLength}"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:apply-templates select="$e/@dt:minLength | $e/@dt:maxLength"/>
        </xsl:otherwise>
      </xsl:choose>  
    </xs:restriction>
  </xs:simpleType>
</xsl:template>  <!-- Testcase: "test-attributes.xml" -->

<xsl:template name="simpleType-with-enum">
  <!-- expects the context to be an xdr:ElementType -->
  <xsl:param name="name"/>
  <xsl:variable name="e" select="(. | xdr:datatype)[last()]"/>
  <xs:simpleType>
    <xsl:if test="$name">
      <xsl:attribute name="name"><xsl:value-of select="$name"/></xsl:attribute>
    </xsl:if>
    <xs:restriction base="xs:NMTOKEN">
      <xsl:call-template name="construct-enum">
        <xsl:with-param name="values" select="string($e/@dt:values)"/>
      </xsl:call-template>
    </xs:restriction>
  </xs:simpleType>
</xsl:template>

<!-- Recursive template to split dt:values tokens and return an
     <xs:enumeration> element for each one. -->
<xsl:template name="construct-enum">
  <xsl:param name="values"/>
  <xsl:variable name="first-token" select="substring-before(concat($values,' '), ' ')"/>
  <xsl:variable name="remaining-tokens" select="substring-after($values, ' ')"/>
  <xsl:if test="$first-token">
    <xs:enumeration value="{$first-token}"/>
  </xsl:if>
  <xsl:if test="$remaining-tokens">
    <xsl:call-template name="construct-enum">
      <xsl:with-param name="values" select="$remaining-tokens"/>
    </xsl:call-template>
  </xsl:if>
</xsl:template>


<!-- element content -->

<xsl:template match="xdr:ElementType">
  <xsl:variable name="e" select="(. | xdr:datatype)[last()]"/>
  
  <xsl:comment> [XDR-XSD] "<xsl:value-of select="@name"/>" complexType  </xsl:comment>
  
  <!-- In the case of enumerated or datatype allowing a min or max 
       length, and attributes (or an open content model which would
       allow attributes) we need to do a two-step process.  First, 
       generate a simple type with the desired restrictions (enumerated
       values or min and max length).  Later on we can declare a complex
       type derived from this simple type to accomodate the attributes. -->
  <xsl:if test="(@content='textOnly' or $e/@dt:type) and (xdr:attribute or not(@model='closed'))">
    <xsl:if test="$e/@dt:type[.='enumeration']">
      <xsl:call-template name="simpleType-with-enum">
        <xsl:with-param name="name" select="concat('generated-type-', generate-id())"/>
      </xsl:call-template>
    </xsl:if>
    <xsl:if test="$e/@dt:maxLength or $e/@dt:minLength">
      <xsl:call-template name="simpleType-with-length">
        <xsl:with-param name="name" select="concat('generated-type-', generate-id())"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:if>
    
    <xsl:call-template name="attribute-annotations"/>
    <!-- done creating attributes -->
    
    <xsl:call-template name="annotations"/>

    <xsl:choose>
      
      <!-- If an explicit datatype is specified, then the content
           attribute is ignored, and treated as textOnly.  -->
      <xsl:when test="@content='textOnly' or $e/@dt:type">
        <!-- Note that model="open" does not allow elements to be added,
             only attributes. -->
        <xsl:choose>
          <xsl:when test="xdr:attribute or not(@model='closed')">
            <!-- content model allows attributes -->
            <xs:complexType>
              <xs:simpleContent>
                <xs:extension>
                  <xsl:attribute name="base">
                    <xsl:choose>
                      <xsl:when test="$e/@dt:type='enumeration' or $e/@dt:maxLength or $e/@dt:minLength">
                        <!-- Refer to a type generated previously. -->
                        <xsl:text>generated-type-</xsl:text>
                        <xsl:value-of select="generate-id()"/>
                      </xsl:when>
                      <xsl:when test="$e/@dt:type">
                        <xsl:apply-templates select="$e/@dt:type" mode="convert-datatype"/>
                      </xsl:when>
                      <xsl:otherwise>xs:string</xsl:otherwise>
                    </xsl:choose>
                  </xsl:attribute>
                  <xsl:call-template name="attribute-content"/>
                  <xsl:call-template name="any-attribute"/>
                </xs:extension>
              </xs:simpleContent>
            </xs:complexType>
          </xsl:when>
      
          <xsl:when test="$e/@dt:maxLength or $e/@dt:minLength">
            <xsl:call-template name="simpleType-with-length"/>
          </xsl:when>
          
          <xsl:otherwise>
            
            <!-- JT: added -->
            <xs:complexType>

              <xsl:attribute name="name">
                <xsl:value-of select="concat(@name, 'Type')"/>
              </xsl:attribute>

              <xs:simpleContent>
                <xs:extension>
                  <xsl:attribute name="base">
					<!-- test is to handle sql_variant that just comes back blank -->
					<xsl:choose>
						<xsl:when test="count($e/@dt:type) = 0">
							<xsl:text>xs:string</xsl:text>
						</xsl:when>
						<xsl:otherwise>
							<xsl:apply-templates select="$e/@dt:type" mode="convert-datatype"/>
						</xsl:otherwise>
					</xsl:choose>
                  </xsl:attribute>
				</xs:extension>
			  </xs:simpleContent>			  

			</xs:complexType>

          </xsl:otherwise>
          
          <!-- General case (simple type, no attributes) is handled
               by generating a type attribute (see beginning of this
               template) instead of simpleType elements.  -->
        </xsl:choose>
      </xsl:when>  <!-- Testcase: "test-textOnly-content.xml" -->
      
      <!-- empty content -->
      <xsl:when test="@content='empty'">
        <xs:complexType>

          <!-- JT: -->          
          <xsl:attribute name="name">
			<xsl:value-of select="concat(@name, 'Type')"/>
          </xsl:attribute>

          <xsl:call-template name="any"/>
          <xsl:call-template name="attribute-content"/>
          <xsl:call-template name="any-attribute"/>
        </xs:complexType>
      </xsl:when>  <!-- Testcase: "test-empty-content.xml" -->
      
      <!--  element only content -->
      <xsl:when test="@content='eltOnly'">
        <xs:complexType>

          <xsl:attribute name="name">
			<xsl:value-of select="concat(@name, 'Type')"/>
          </xsl:attribute>
          
          <xsl:choose>

            <xsl:when test="@order='one'">
              <xsl:choose>
                <xsl:when test="not(@model='closed')">
                  <!-- This is an unlikely case - an open model conflicts 
                       with the order='one' restriction, which is likely to 
                       produce results unexpected by the user.  XDR 
                       documentation warns against this combination, but 
                       allows it.  Thus the behavior is duplicated here. -->
                  <xs:sequence>
                    <xsl:if test="xdr:element | xdr:group | comment()">
                      <xs:choice>
                        <xsl:call-template name="element-content"/>
                      </xs:choice>
                    </xsl:if>
                    <xsl:call-template name="any"/>
                  </xs:sequence>
                  <xsl:call-template name="attribute-content"/>
                  <xsl:call-template name="any-attribute"/>
                </xsl:when>
                <xsl:otherwise>
                  <!-- model is closed -->
                  <xsl:if test="xdr:element | xdr:group | comment()">
                    <xs:choice>
                      <xsl:call-template name="element-content"/>
                    </xs:choice>
                  </xsl:if>
                  <xsl:call-template name="attribute-content"/>
                </xsl:otherwise>
              </xsl:choose>
            </xsl:when>
            
            <xsl:when test="@order='many'">
              <xsl:if test="(xdr:element | xdr:group | comment()) or not(@model='closed')">
                <xs:choice minOccurs="0" maxOccurs="unbounded">
                  <xsl:call-template name="element-content"/>
                  <xsl:call-template name="any"/>
                </xs:choice>
              </xsl:if>
              <xsl:call-template name="attribute-content"/>
              <xsl:call-template name="any-attribute"/>
            </xsl:when>
            
            <!-- @order='seq' or @order isn't specified (which defaults to 'seq' when @content='eltOnly') -->
            <xsl:otherwise>
              <xsl:if test="(xdr:element | xdr:group | comment()) or not(@model='closed')">
                <xs:sequence>
                  <xsl:call-template name="element-content"/>
                  <xsl:call-template name="any"/>
                </xs:sequence>
              </xsl:if>
              <xsl:call-template name="attribute-content"/>
              <xsl:call-template name="any-attribute"/>
            </xsl:otherwise>
          </xsl:choose>
        </xs:complexType>
      </xsl:when>  <!-- Testcase: "test-eltOnly-content.xml" -->
      
      <!-- content='mixed' or is not specified, in which case it
           defaults to 'mixed' if the order attribute has the value
           'many' or is not specified. -->
      <xsl:otherwise>
        <xsl:if test="@order='one' or @order='seq'">
          <xsl:comment>
            [XDR-XSD] ****Warning!****
            Original schema illegally combined content="mixed" and @order="<xsl:value-of select="@order"/>".
            Treating this as order='many' instead.
          </xsl:comment>
        </xsl:if>
        <xs:complexType mixed="true">
          <xsl:if test="(xdr:element | xdr:group | comment()) or not(@model='closed')">
            <xs:choice minOccurs="0" maxOccurs="unbounded">
              <xsl:call-template name="element-content"/>
              <xsl:if test="not(@model='closed')">
                <xs:any namespace="##other" processContents="lax"/>
                <!-- DO NOT USE instruction below because it causes non-deterministic state in schema when located within
                elements which minOccurs="0" -->
                <!-- <xs:any namespace="##targetNamespace"/> -->
              </xsl:if>
            </xs:choice>
          </xsl:if>
          <xsl:call-template name="attribute-content"/>
          <xsl:call-template name="any-attribute"/>
        </xs:complexType>
      </xsl:otherwise>  <!-- Testcase: "test-mixed-content.xml" -->
      
    </xsl:choose>
  
</xsl:template>

<xsl:template match="xdr:element">

  <xs:element>
    <xsl:attribute name="name">
      <xsl:value-of select="@type"/>
    </xsl:attribute>
    <xsl:attribute name="type">
      <xsl:value-of select="concat(@type, 'Type')"/>
    </xsl:attribute>

    <xsl:apply-templates select="@minOccurs | @maxOccurs"/>
    <xsl:call-template name="attribute-annotations"/>
    <!-- write annotations from corresponding xdr:ElementType element if there are no annotations defined for this xdr:element,
         and use annotations from the xdr:element otherwise. -->
    <xsl:choose>
	  <!-- check if this element has annotations -->
      <xsl:when test="*[not(self::xdr:*)]">
        <xsl:call-template name="annotations"/>
      </xsl:when>
      <!-- check if declaration of this element has annotations -->
      <xsl:when test="/xdr:Schema/xdr:ElementType[@name=current()/@type]/*[not(self::xdr:*)]">
        <xsl:call-template name="annotations"/>
	  </xsl:when>
	</xsl:choose>
  </xs:element>
</xsl:template>

<xsl:template match="xdr:group">
  <!-- Trace the inheritance to discover what "order" value applies -->
  <xsl:variable name="inherited-order">
    <xsl:choose>
      <xsl:when test="ancestor-or-self::xdr:group[@order]">
        <xsl:value-of select="ancestor-or-self::xdr:group[@order][1]/@order"/>
      </xsl:when>
      <xsl:when test="ancestor::xdr:ElementType[@order]">
        <xsl:value-of select="ancestor::xdr:ElementType[@order]/@order"/>
      </xsl:when>
      <xsl:when test="ancestor::xdr:ElementType/@content='eltOnly'">seq</xsl:when>
      <xsl:otherwise>many</xsl:otherwise>
    </xsl:choose>
  </xsl:variable>
  <!-- Translate "order" into the name of a group -->
  <xsl:variable name="group-name">
    <xsl:choose>
      <xsl:when test="$inherited-order='one'">choice</xsl:when>
      <xsl:when test="$inherited-order='seq'">sequence</xsl:when>
      <xsl:when test="$inherited-order='many'">choice</xsl:when>
    </xsl:choose>
  </xsl:variable>

  <xsl:element name="xs:{$group-name}">
    <xsl:choose>
      <xsl:when test="$inherited-order='many'">
        <xsl:attribute name="minOccurs">0</xsl:attribute>
        <xsl:attribute name="maxOccurs">unbounded</xsl:attribute>
      </xsl:when>
      <xsl:otherwise>
        <xsl:apply-templates select="@minOccurs | @maxOccurs"/>
      </xsl:otherwise>
    </xsl:choose>
    <xsl:call-template name="attribute-annotations"/>
    <xsl:call-template name="annotations"/>
    <xsl:call-template name="element-content"/>
  </xsl:element>
</xsl:template>

<!-- attribute content -->

<!-- Generate global attributes, even if these aren't referenced anywhere. -->
<xsl:template match="xdr:Schema/xdr:AttributeType">
  <xs:attribute name="{@name}">
    <xsl:apply-templates select="@required"/>
    <xsl:choose>
      <xsl:when test="@required='yes' and @default">
        <xsl:attribute name="fixed"><xsl:value-of select="@default"/></xsl:attribute>
      </xsl:when>
      <xsl:when test="@default">
        <xsl:attribute name="default"><xsl:value-of select="@default"/></xsl:attribute>
      </xsl:when>
    </xsl:choose>        
        
    <!-- enumerations and types with a specified minLength or maxLength cannot be
         expressed through XSD attributes, so don't handle them yet.  -->
    <xsl:if test="not(@dt:maxLength or xdr:datatype/@dt:maxLength or @dt:minLength or xdr:datatype/@dt:minLength or @dt:type[.='enumeration'] or xdr:datatype[@dt:type='enumeration'])">
      <xsl:apply-templates select="@dt:type | xdr:datatype"/>
    </xsl:if>
    
    <xsl:call-template name="attribute-annotations"/>
    <!-- done generating attributes -->

    <!-- description and annotations -->
    <xsl:apply-templates select="comment()"/>
    <xsl:call-template name="annotations"/>
    
    <!-- generate an anonymous type with the enumerated values -->
    <xsl:apply-templates select="@dt:type[.='enumeration'] | xdr:datatype[@dt:type='enumeration']"/>

    <!-- generate an anonymous type with the minLength or maxLength restrictions -->
    <xsl:if test="@dt:minLength or xdr:datatype/@dt:minLength or @dt:maxLength or xdr:datatype/@dt:maxLength">
      <xsl:call-template name="simpleType-with-length"/>
    </xsl:if>
  </xs:attribute>
</xsl:template>

<!-- Local attribute definitions are preserved as local content types -->
<xsl:template match="xdr:AttributeType"/>

<xsl:template match="xdr:attribute">
  <!-- Find the applicable (closest) AttributeType definition. -->
  <xsl:variable name="definition" select="ancestor::*[xdr:AttributeType/@name = current()/@type][1]/xdr:AttributeType[@name = current()/@type]"/>

  <xsl:choose>
    <!--
      Note that XDR allows attribute references to be further refined (default 
      values) more heavily than XSD, so when default values appear on the
      attribute declaration, the information must be copied from the global
      attribute.
    -->
    <xsl:when test="not(@default) and $definition/parent::xdr:Schema">
      <xs:attribute ref="{@type}">
        <xsl:apply-templates select="@required"/>
        <xsl:call-template name="attribute-annotations"/>
        <xsl:call-template name="annotations"/>
      </xs:attribute>
    </xsl:when>

    <xsl:otherwise>
      <xs:attribute name="{@type}">

        <!-- required attribute on the attribute declaration override that on the definition -->
        <xsl:choose>
          <xsl:when test="@required"><xsl:apply-templates select="@required"/></xsl:when>
          <xsl:otherwise><xsl:apply-templates select="$definition/@required"/></xsl:otherwise>
        </xsl:choose>

        <!-- if required="yes" and default is specified, this indicates a fixed
             value, and thus needs a "fixed" attribute instead of a "default"
             attribute.  -->
        <xsl:choose>
          <!-- default attribute on the attribute declaration override that on 
               the definition -->
          <xsl:when test="($definition/@required='yes' or @required='yes')">
            <xsl:choose>
              <xsl:when test="@default">
                <xsl:attribute name="fixed">
                  <xsl:value-of select="@default"/>
                </xsl:attribute>
              </xsl:when>
              <xsl:when test="$definition/@default">
                <xsl:attribute name="fixed">
                  <xsl:value-of select="$definition/@default"/>
                </xsl:attribute>
              </xsl:when>
            </xsl:choose>
          </xsl:when>
          <xsl:otherwise>
            <xsl:choose>
              <xsl:when test="@default">
                <xsl:attribute name="default">
                  <xsl:value-of select="@default"/>
                </xsl:attribute>
              </xsl:when>
              <xsl:when test="$definition/@default">
                <xsl:attribute name="default">
                  <xsl:value-of select="$definition/@default"/>
                </xsl:attribute>
              </xsl:when>
            </xsl:choose>
          </xsl:otherwise>
        </xsl:choose>
                
        <!-- enumerations and types with a specified minLength or maxLength cannot be
             expressed through XSD attributes, so don't handle them yet.  -->
        <xsl:if test="not($definition[@dt:maxLength or xdr:datatype/@dt:maxLength or @dt:minLength or xdr:datatype/@dt:minLength or @dt:type[.='enumeration'] or xdr:datatype[@dt:type='enumeration']])">
          <xsl:apply-templates select="$definition/@dt:type | $definition/xdr:datatype"/>
        </xsl:if>

		<!-- JT: added to deal with sql_variant type which just comes back blank -->
		<xsl:if test="count($definition/@dt:type)=0">
		  <xsl:attribute name="type">xs:string</xsl:attribute>
		</xsl:if>
		
        <xsl:call-template name="attribute-annotations"/>
        <!-- done generating attributes -->

        <xsl:apply-templates select="$definition/comment()"/>

        <!-- description and annotations -->
        <xsl:call-template name="annotations"/>

        <!-- generate an anonymous type with the enumerated values -->
        <xsl:apply-templates select="$definition/@dt:type[.='enumeration'] | $definition/xdr:datatype[@dt:type='enumeration']"/>

        <!-- generate an anonymous type with the minLength or maxLength restrictions -->
        <xsl:for-each select="$definition[@dt:minLength or @dt:maxLength or xdr:datatype[@dt:minLength or @dt:maxLength]]">
          <xsl:call-template name="simpleType-with-length"/>
        </xsl:for-each>
      </xs:attribute>
    </xsl:otherwise>
  </xsl:choose>
</xsl:template>  <!-- Testcase: "test-attributes.xml" -->

<!-- other constructs -->

<!-- descriptions are handled elsewhere, ignore any 
     that fell through the cracks -->
<xsl:template match="xdr:description"/>

<!--  attribute conversion templates -->

<xsl:template match="@*"/>

<xsl:template match="@dt:minLength">
  <xs:minLength value="{.}"/>
</xsl:template>

<xsl:template match="@dt:maxLength">
  <xs:maxLength value="{.}"/>
</xsl:template>

<xsl:template match="@minOccurs | @maxOccurs">
  <xsl:if test=". != '1'">
    <xsl:copy/>
  </xsl:if>
</xsl:template>

<xsl:template match="@maxOccurs[.='*']">
  <xsl:attribute name="maxOccurs">unbounded</xsl:attribute>
</xsl:template>

<xsl:template match="@default">
  <xsl:attribute name="use">optional</xsl:attribute>
  <xsl:attribute name="default"><xsl:value-of select="."/></xsl:attribute>
</xsl:template>

<xsl:template match="@required[.='yes']">
  <xsl:attribute name="use">required</xsl:attribute>
</xsl:template>

<xsl:template match="@required[.='no']">
  <xsl:attribute name="use">optional</xsl:attribute>
</xsl:template>

<!--  Data type attribute/element conversions -->

<xsl:template match="@dt:type">
  <xsl:attribute name="type">
    <xsl:apply-templates select="." mode="convert-datatype"/>
  </xsl:attribute>
</xsl:template>

<xsl:template match="xdr:datatype">
  <xsl:apply-templates select="@dt:type"/>
</xsl:template>

<xsl:template match="@dt:type[.='enumeration']">
  <xsl:for-each select="..">
    <xsl:call-template name="simpleType-with-enum"/>
  </xsl:for-each>
</xsl:template>  <!-- Testcase: "test-attributes.xml" -->

<!--
  convert-datatype mode just returns the converted datatype value, instead
  of an attribute with the converted value.  These are special cases needed
  for dt:minLength, dt:maxLength conversions.
-->

<!-- no conversion for enumerations, which must be handled separately -->
<xsl:template mode="convert-datatype" match="@dt:type[.='enumeration']">xs:enumeration</xsl:template>

<xsl:template mode="convert-datatype" match="@dt:type"><xsl:value-of select="."/></xsl:template>
<!-- char, date, dateTime, fixed14.1, r4, time, uuid -->

<!-- JT: added the following for SQL XDR support -->
<xsl:template mode="convert-datatype" match="@dt:type[.='char']">char</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='date']">xs:date</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='dateTime']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='time']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='fixed.14.1']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='fixed.14.2']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='fixed.14.3']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='fixed.14.4']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='fixed.14.5']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='fixed.14.6']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='fixed.14.7']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='fixed.14.8']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='fixed.14.9']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='fixed.14.10']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='fixed.14.11']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='fixed.14.12']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='fixed.14.13']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='fixed.14.14']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='r4']">xs:float</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='uuid']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='real']">xs:float</xsl:template>

<xsl:template mode="convert-datatype" match="@dt:type[.='bin.base64']">xs:base64Binary</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='bin.hex']">xs:hexBinary</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='boolean']">xs:boolean</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='dateTime.tz']">xs:dateTime</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='entity']">xs:ENTITY</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='entities']">xs:ENTITIES</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='float']">xs:float</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='i1']">xs:byte</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='i2']">xs:short</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='i4']">xs:int</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='i8']">xs:long</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='id']">xs:ID</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='idref']">xs:IDREF</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='idrefs']">xs:IDREFS</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='int']">xs:integer</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='nmtoken']">xs:NMTOKEN</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='nmtokens']">xs:NMTOKENS</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='notation']">xs:NOTATION</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='number']">xs:decimal</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='r8']">xs:double</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='string']">xs:string</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='time.tz']">xs:time</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='ui1']">xs:unsignedByte</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='ui2']">xs:unsignedShort</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='ui4']">xs:unsignedInt</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='ui8']">xs:unsignedLong</xsl:template>
<xsl:template mode="convert-datatype" match="@dt:type[.='uri']">xs:anyURI</xsl:template>

</xsl:stylesheet>