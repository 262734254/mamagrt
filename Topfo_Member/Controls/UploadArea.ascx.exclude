<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UploadArea.ascx.cs" Inherits="UploadArea" %>
<%@ Register Assembly="Krystalware.SlickUpload" Namespace="Krystalware.SlickUpload.Controls"
    TagPrefix="kw" %>
<%@ Import Namespace="Krystalware.SlickUpload" %>
<style type="text/css">
table.results {border-collapse:collapse;border:1px solid #c0c0c0}
table.results td, table.results th {border:1px solid #c0c0c0; font-weight:none}
table.results th {background-color:#e0e0e0}
</style>
<asp:Label ID="resultsMessage" runat="server" Text=""></asp:Label>
<asp:Panel ID="uploadPanel" runat="server" Width="100%">
    <kw:UploadManager ID="uploadManager" runat="server"   OnUploadComplete="uploadManager_UploadComplete" Width="100%">
        <ProgressAreaTemplate>
            <table width="100%">
                <tr>
                    <td>
                        正在上传 <kw:ProgressElement id="progressElement1" element="FileCountText" runat="server"></kw:ProgressElement>, <kw:ProgressElement id="progressElement7" element="ContentLengthText" runat="server"></kw:ProgressElement>.
                    </td>
                </tr>
                <tr>
                    <td>
                        当前上传: <kw:ProgressElement id="progressElement2" element="CurrentFileName" runat="server"></kw:ProgressElement>,  <kw:ProgressElement id="progressElement6" element="CurrentFileIndex" runat="server"></kw:ProgressElement> / <kw:ProgressElement id="progressElement5" element="FileCount" runat="server"></kw:ProgressElement>.
                    </td>
                </tr>
                <tr>
                    <td>
                        速度: <kw:ProgressElement id="progressElement3" element="SpeedText" runat="server"></kw:ProgressElement>.
                    </td>
                </tr>
                <tr>
                    <td>
                        大约 <kw:ProgressElement id="progressElement4" element="TimeRemainingText" runat="server"></kw:ProgressElement>.
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="border:1px solid #008800;height:30px">
                            <kw:ProgressBarElement  id="progressBarElement1" style="POSITION: relative;margin-bottom:-22px; background-color:#00ee00;width:0;height:30px" runat="server">
                            </kw:ProgressBarElement>
                            <div style="text-align:center;position:relative">
                                <kw:ProgressElement id="progressElement8" element="PercentCompleteText" runat="server"></kw:ProgressElement>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>    
        </ProgressAreaTemplate>
    </kw:UploadManager>
    <asp:Button ID="submitButton" runat="Server" Text="上传" OnClick="submitButton_Click" />
    <a href="javascript:SlickUpload_CancelUpload()" class="suCancelButton" style="display:none">取消</a></asp:Panel>