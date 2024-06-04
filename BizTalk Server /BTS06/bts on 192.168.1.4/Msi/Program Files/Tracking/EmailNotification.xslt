<?xml version="1.0" encoding="UTF-8" ?>

<!--Copyright (c) Microsoft Corporation. All rights reserved.-->

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"  xmlns:msxsl="urn:schemas-microsoft-com:xslt">
  <xsl:template match="notifications">

    <html>
      <body>
        <xsl:apply-templates/>
        <br/><br/>
        Delivered by BAM.<br/><br/>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="notification">
    <br/>
    Alert: <xsl:value-of select="AlertName" /> <br/>
    Message:<xsl:value-of select="Message" /> <br/>
    <a>
      <xsl:attribute name="href">
        <xsl:value-of select="NotificationURL" />
      </xsl:attribute>Webpage
    </a><br/>
  </xsl:template>
</xsl:stylesheet>