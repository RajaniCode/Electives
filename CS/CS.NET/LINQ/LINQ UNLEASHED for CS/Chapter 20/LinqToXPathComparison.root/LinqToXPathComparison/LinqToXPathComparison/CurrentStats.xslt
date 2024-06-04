<?xml version='1.0'?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <html>
      <head>
        <style type="text/css">
          table
          {
            cellspacing: 0;
            cellpadding: 0;
            border-top: "1 solid #000000";
            border-bottom: "1 solid #000000";
            border-right: "1 solid #000000";
            border-left: "1 solid #000000";
          }
          td.Header
          {
            background-color: "#000111";
            color: "#FFFFFF";
            border: "1 solid #000000";
          }
          td.Name
          {
            background-color: "silver";
            border: "1 solid #000000";
          }
          td.Data
          {
            text-align: right;
            width: 100px;
            border-bottom: "1 solid #000000";
          }
        </style>
      </head>
      <body>
        <table cellspacing="0" cellpadding="0">
          <xsl:for-each select="Blackjack/Player/Statistics">
            <tr>
              <td class="Header">Name</td>
              <td class="Header">Value</td>
            </tr>
            <tr>
              <td class="Name"> 
                Average Amount Lost:
              </td>
              <td class="Data">
                <strong>
                  <xsl:value-of select='format-number(AverageAmountLost, "#.000")' />
                </strong>
              </td>
            </tr>
            <tr>
              <td class="Name">
                Average Amount Won:
              </td>
              <td class="Data">
                <strong>
                  <xsl:value-of select='format-number(AverageAmountWon, "#.000")'/>
                </strong>
              </td>
            </tr>
            <tr>
              <td class="Name">
                Losses:
              </td>
              <td class="Data">
                <strong>
                  <xsl:value-of select="Losses"/>
                </strong>
              </td>
            </tr>
            <tr>
              <td class="Name"> 
                Blackjacks:
              </td>
              <td class="Data">
                <strong>
                  <xsl:value-of select="Blackjacks"/>
                </strong>
              </td>
            </tr>
            <tr>
              <td class="Name"> 
                Net Average Win Loss:
              </td>
              <td class="Data">
                <strong>
                  <xsl:value-of select='format-number(NetAverageWinLoss, "0.000")'/>
                </strong>
              </td>
            </tr>
            <tr>
              <td class="Name"> 
                Net Win Loss: 
              </td>
              <td class="Data">
                <strong>
                  <xsl:value-of select="NetWinLoss"/>
                </strong>
              </td>
            </tr>
            <tr>
              <td class="Name"> 
                Percentage of Blackjacks:
              </td>
              <td class="Data">
                <strong>
                  <xsl:value-of select='format-number(PercentageOfBlackJacks, "0.000%")'/>
                </strong>
              </td>
            </tr>
            <tr>
              <td class="Name"> 
                Percentage of Losses:
              </td>
              <td class="Data">
                <strong>
                  <xsl:value-of select='format-number(PercentageOfLosses div 100, "0.000%")' />
                </strong>
              </td>
            </tr>
            <tr>
              <td class="Name"> 
                Percentage of Pushes:
              </td>
              <td class="Data">
                <strong>
                  <xsl:value-of select='format-number(PercentageOfPushes div 100, "0.000%")'/>
                </strong>
              </td>
            </tr>
            <tr>
              <td class="Name"> 
                Percentage of Wins:
              </td>
              <td class="Data">
                <strong>
                  <xsl:value-of select='format-number(PercentageOfWins div 100, "0.000%")'/>
                </strong>
              </td>
            </tr>
            <tr>
              <td class="Name"> 
                Pushes:
              </td>
              <td class="Data">
                <strong>
                  <xsl:value-of select="Pushes"/>
                </strong>
              </td>
            </tr>
            <tr>
              <td class="Name"> 
                Pushes:
              </td>
              <td class="Data">
                <strong>
                  <xsl:value-of select="Pushes"/>
                </strong>
              </td>
            </tr>
            <tr>
              <td class="Name"> 
                Surrenders:
              </td>
              <td class="Data">
                <strong>
                  <xsl:value-of select="Surrenders"/>
                </strong>
              </td>
            </tr>
            <tr>
              <td class="Name"> 
                Total Amount Won or Lost:
              </td>
              <td class="Data">
                <strong>
                  <xsl:value-of select="TotalAmountLost"/>
                </strong>
              </td>
            </tr>
            <tr>
              <td class="Name"> 
                Total Amount Won:
              </td>
              <td class="Data">
                <strong>
                  <xsl:value-of select="TotalAmountWon"/>
                </strong>
              </td>
            </tr>
            <tr>
              <td class="Name"> 
                Wins:
              </td>
              <td class="Data">
                <strong>
                  <xsl:value-of select="Wins"/>
                </strong>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>

