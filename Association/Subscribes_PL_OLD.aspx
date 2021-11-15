<%@ Page Title="" Language="C#" MasterPageFile="~/AssocMaster.Master" AutoEventWireup="true" CodeBehind="Subscribes_PL_OLD.aspx.cs" Inherits="Association.Subscribes_PL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="upInfo" runat="server">
        <ContentTemplate>

            <fieldset>
                <legend>شاشة إدخال المشتركين</legend>

                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="ddl_Year">السنة</label>
                            <asp:DropDownList ID="ddl_Year" runat="server" CssClass="form-control"></asp:DropDownList>

                            <asp:RequiredFieldValidator ID="rfvddlOrg" runat="server" ControlToValidate="ddl_Year"
                                ForeColor="Red" SetFocusOnError="true" ErrorMessage="من فضلك إختر السنة." CssClass="text-error" InitialValue="0">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="ddl_Month">الشهر</label>
                            <asp:DropDownList ID="ddl_Month" runat="server" CssClass="form-control"></asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_Month"
                                ForeColor="Red" SetFocusOnError="true" ErrorMessage="من فضلك إختر الشهر." CssClass="text-error" InitialValue="0">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="txtSub_Paied">المبلغ</label>
                            <asp:TextBox ID="txtSub_Paied" runat="server" placeholder="المبلغ" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSub_Paied"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="من فضلك أدخل المبلغ." CssClass="text-error">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:Panel ID="pnlUpload" runat="server">
                                <div class="fileinput fileinput-new" data-provides="fileinput">
                                    <span class="btn btn-default btn-file"><span class="fileinput-new">إختر ملف</span><span class="fileinput-exists">Change</span>
                                        <asp:FileUpload ID="FUFile" runat="server" name="..." />
                                    </span>
                                    <span class="fileinput-filename"></span>
                                    <a href="#" class="close fileinput-exists" data-dismiss="fileinput" style="float: none">&times;</a>
                                </div>

                                <asp:Button ID="btnUpload" runat="server" OnClick="Upload_Event_Click" CssClass="btn btn-default" Text="قم برفع الملف" ValidationGroup="A" />
                            </asp:Panel>


                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ForeColor="Red"  
                                ControlToValidate="FUFile" ErrorMessage="لم تقم بإخيار الملف ">
                            </asp:RequiredFieldValidator>

                  
                        </div>
                    </div>
                </div>



                <div style="width: 500px; margin: 0 auto; font-size: medium; text-align: center; color: red; padding: 5px;">
                    <asp:Label ID="lblMsg_Success" runat="server" CssClass="text-success"></asp:Label>
                    <asp:Label ID="lblError" runat="server" CssClass="text-error"></asp:Label>
                </div>

            </fieldset>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
    </asp:UpdatePanel>

    <div class="table-responsive">
        <asp:GridView ID="gvSubscribes" AutoGenerateColumns="false" runat="server" CssClass="table table-striped table-condensed table-bordered table-hover" OnRowDataBound="gvSubscribes_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Sub_Year" HeaderText="السنة" />
                <asp:BoundField DataField="Mem_ID" HeaderText="رقم المشترك" />
                <asp:BoundField DataField="Memb_Name" HeaderText="الإسم" />
                <asp:BoundField DataField="Sub_Paied" HeaderText="المبلغ" />
                <asp:BoundField DataField="Jan" HeaderText="يناير" />
                <asp:BoundField DataField="Feb" HeaderText="فبراير" />
                <asp:BoundField DataField="Mar" HeaderText="مارس" />
                <asp:BoundField DataField="Apr" HeaderText="إبريل" />
                <asp:BoundField DataField="May" HeaderText="مايو" />
                <asp:BoundField DataField="June" HeaderText="يونيو" />
                <asp:BoundField DataField="July" HeaderText="يوليو" />
                <asp:BoundField DataField="August" HeaderText="أغسطس" />
                <asp:BoundField DataField="Sep" HeaderText="سبتمبر" />
                <asp:BoundField DataField="Oct" HeaderText="أكتوبر" />
                <asp:BoundField DataField="Nov" HeaderText="نوفمبر" />
                <asp:BoundField DataField="Dec" HeaderText="ديسمبر" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
