<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:h="http://www.w3.org/1999/xhtml" xmlns:c="company" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/data">
      <html xmlns="http://www.w3.org/1999/xhtml">
        <body> 
          <h1>Demo Document</h1>
          <p>
            <ul>
              <xsl:apply-templates/>
            </ul>
          </p>
        </body>
      </html>
    </xsl:template>
    <xsl:template match="person">
      <li xmlns="http://www.w3.org/1999/xhtml">
        <xsl:value-of select="name"/>
        <xsl:apply-templates/>
      </li>
    </xsl:template>
    <xsl:template match="c:company">
      (<xsl:value-of select="c:name"/>)
    </xsl:template>
    <xsl:template match="text()"></xsl:template>
</xsl:stylesheet>