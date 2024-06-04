<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
                version="1.0">
<xsl:template match="/">
<HTML>
  <BODY>
    <TABLE BORDER="0" cellspacing="3" cellpadding="8">
      <TR bgcolor="#FFCC00">
        <TD>Product Name</TD>
        <TD>Price</TD>
        <TD>Discount</TD>
        <TD>Quantity</TD>
        <TD>Total</TD>
      </TR>
      <xsl:apply-templates select="XmlDb/Products[position() &lt; 10]">
        <xsl:sort select="UnitPrice" order="descending" data-type = "number" />
        
      </xsl:apply-templates>      
    </TABLE>
  </BODY>
</HTML>
</xsl:template>
<xsl:decimal-format name="us" decimal-separator='.' grouping-separator=',' />
<xsl:template match="XmlDb/Products[position() &lt; 10]">
<TR >
<xsl:if test="position() mod 2 = 0">
      <xsl:attribute name="bgcolor">#EEEEEE</xsl:attribute>
</xsl:if>
<xsl:if test="position() mod 2 = 1">
      <xsl:attribute name="bgcolor">#AAAAAA</xsl:attribute>
</xsl:if>
        <TD><xsl:value-of select="ProductName"/></TD>
        <TD><xsl:value-of select="format-number(UnitPrice, '#.00', 'us')"/>$</TD>
<xsl:if test="number(OrderDetails/Discount) != 0">
        <TD>-<xsl:value-of select="number(OrderDetails/Discount)*100"/>%</TD>
</xsl:if>
<xsl:if test="number(OrderDetails/Discount) = 0">
        <TD>-----</TD>
</xsl:if>
       <TD><xsl:value-of select="OrderDetails/Quantity"/></TD>
        <TD><xsl:value-of select="number(UnitPrice)*number(OrderDetails/Quantity)*(1-number(OrderDetails/Discount))"/>$</TD>
      </TR>
      </xsl:template>
</xsl:stylesheet>
  