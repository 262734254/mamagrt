<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="Controls_WebUserControl" %>
<%@ Register Assembly="Krystalware.SlickUpload" Namespace="Krystalware.SlickUpload.Controls"
    TagPrefix="kw" %>
文件名称：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
<kw:uploadmanager id="UploadManager1" runat="server">
        <ProgressAreaTemplate>
            <table width="100%">
                <tr>
                    <td>
                        Uploading <kw:ProgressElement id="fileCountElement" element="FileCountText" runat="server"></kw:ProgressElement>, <kw:ProgressElement id="contentLengthText" element="ContentLengthText" runat="server"></kw:ProgressElement>.
                    </td>
                </tr>
                <tr>
                    <td>
                        Currently uploading: <kw:ProgressElement id="currentFileNameElement" element="CurrentFileName" runat="server"></kw:ProgressElement>, file <kw:ProgressElement id="currentFileIndex" element="CurrentFileIndex" runat="server"></kw:ProgressElement> of <kw:ProgressElement id="fileCountElement2" element="FileCount" runat="server"></kw:ProgressElement>.
                    </td>
                </tr>
                <tr>
                    <td>
                        Speed: <kw:ProgressElement id="speedTextElement" element="SpeedText" runat="server"></kw:ProgressElement>.
                    </td>
                </tr>
                <tr>
                    <td>
                        About <kw:ProgressElement id="timeRemainingTextElement" element="TimeRemainingText" runat="server"></kw:ProgressElement>&nbsp;remaining.
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="border:1px solid #008800;height:1.5em">
                            <kw:ProgressBarElement  id="progressBarElement" style="background-color:#00ee00;width:0;height:1.5em" runat="server">
                            </kw:ProgressBarElement>
                            <div style="text-align:center;position:relative;top:-1.35em">
                                <kw:ProgressElement id="percentCompleteTextElement" element="PercentCompleteText" runat="server"></kw:ProgressElement>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>    
        </ProgressAreaTemplate>
</kw:uploadmanager>
<br />
&nbsp;<br />
