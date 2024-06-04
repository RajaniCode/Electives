<?xml version="1.0" encoding="UTF-8" ?>
<!--Copyright (c) Microsoft Corporation. All rights reserved.-->

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"  xmlns:msxsl="urn:schemas-microsoft-com:xslt">
  <xsl:output method="xml" encoding="utf-8"  />
    <xsl:template match="notifications" >
    <xsl:for-each select="notification">
      <Alert>
        <UserName><xsl:value-of select="UserName"/></UserName>
        <ViewName><xsl:value-of select="ViewName" /></ViewName>
        <Name><xsl:value-of select="AlertName" /></Name>
        <Message><xsl:value-of select="Message" /></Message>
        <WebPage><xsl:value-of select="NotificationURL"/></WebPage>
        <Time><xsl:value-of select="DistributionTime"/></Time>
      </Alert>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>