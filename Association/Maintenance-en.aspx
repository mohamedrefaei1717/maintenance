<%@ Page Title="" Language="C#" MasterPageFile="~/AssocMaster.Master" AutoEventWireup="true" CodeBehind="Maintenance-en.aspx.cs" Inherits="Association.Maintenance" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style1 {
            width: 227px
        }
        .header-title {
            font-weight: bold;
            font-size: 20px;
            text-decoration: underline;
        }

        .main-row {
            margin-bottom: 10px;
        }
    </style>
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form_bg" id ="image">
                    <div class="row">
        <div class="col-sm-12 text-center">
             <span class ="header-title">نموذج إخطار صيانة / تحديث</span>
            <img src="images/1.png" Width ="50" Height="50" alt="Syndicate of Ministry of Communications" title="syndicate" />         
        </div>
    </div>


    <div class="row main-row">
        <div class="col-sm-2 text-center">
            <img src="images/2.png" Width ="50" Height="50" alt="Syndicate of Ministry of Communications" title="syndicate" /> 
            <p><strong>نوع الصيانة</strong></p>
        </div>
        <div class="col-sm-10">
            <div class="row main-row" style ="margin-top:20px;">
                <div class="col-sm-3">
                    <input id="Checkbox1" type="checkbox" />
                            <label for="Checkbox1">دورية</label>
                </div>
                <div class="col-sm-3">
                    <input id="Checkbox2" type="checkbox" />
                            <label for="Checkbox2">تحديث</label>
                </div>
                <div class="col-sm-3">
                    <input id="Checkbox3" type="checkbox" />
                    <label for="Checkbox3">عطل</label>
                </div>
                <div class="col-sm-3">
                    <input id="Checkbox4" type="checkbox" />
                    <label for="Checkbox4">استباقة</label>
                </div>
            </div>
           
        </div>
    </div>

    <div class="row main-row">
        <div class="col-sm-2 text-center">
            <img src="images/3.png" Width ="50" Height="50" alt="Syndicate of Ministry of Communications" title="syndicate" /> 
            <p><strong>توقيت الصيانة / التحديث</strong></p>
        </div>
        <div class="col-sm-10">
            <div class="row main-row">
                <div class="col-md-5">
                    <label for="txtMemb_Date_Contract">التاريخ من </label>
                    <div class="input-group date">
                        <asp:TextBox ID="txtMemb_Date_Contract" runat="server" placeholder="التاريخ من " CssClass="form-control" ReadOnly="true" Style="background-color: white"></asp:TextBox>
                        <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                        
                    </div>
                </div>
                <div class="col-md-5">
                    <label for="txtMemb_Date_Contract">التاريخ إلي </label>
                    <div class="input-group date">
                        <asp:TextBox ID="TextBox1" runat="server" placeholder="التاريخ إلي " CssClass="form-control" ReadOnly="true" Style="background-color: white"></asp:TextBox>
                        <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                        
                    </div>
                </div>
            </div>
            
        </div>
    </div>


    <div class="row main-row">
        <div class="col-sm-2 text-center">
            <img src="images/4.png" Width ="50" Height="50" alt="Syndicate of Ministry of Communications" title="syndicate" /> 
            <p><strong>الخدمات التي ستتأثر</strong></p>
        </div>
        <div class="col-sm-10">
            <div class="row main-row">
                <div class="col-sm-3">
                    <input id="Checkbox5" type="checkbox" />
                        <label for="Checkbox5">Security</label>
                </div>
                <div class="col-sm-3">
                    <input id="Checkbox6" type="checkbox" />
                    <label for="Checkbox6">Voice</label>
                </div>
                <div class="col-sm-3">
                    <input id="Checkbox7" type="checkbox" />
                    <label for="Checkbox7">Wireless</label>
                </div>
                <div class="col-sm-3">
                    <input id="Checkbox9" type="checkbox" />
                    <label for="Checkbox9">Wired</label>
                </div>

                <div class="col-sm-3">
                    <input id="Checkbox10" type="checkbox" />
                        <label for="Checkbox10">Power</label><br />
                </div>
                <div class="col-sm-3">
                    <input id="Checkbox11" type="checkbox" />
                        <label for="Checkbox11">PCs</label>
                </div>
                <div class="col-sm-3">
                    <input id="Checkbox12" type="checkbox" />
                    <label for="Checkbox12">servers</label>
                </div>
                <div class="col-sm-3">
                    <input id="Checkbox13" type="checkbox" />
                    <label for="Checkbox13">Applications</label>
                </div>
                <div class="col-sm-3">
                    <input id="Checkbox14" type="checkbox" />
                    <label for="Checkbox14">E-mails</label>
                </div>

                <div class="col-sm-3">
                    <input id="Checkbox15" type="checkbox" />
                    <label for="Checkbox15">Other</label>
                </div>
            </div>

            
            
        </div>
    </div>

    <div class="row main-row">
        <div class="col-sm-2 text-center">
            <img src="images/5.png" Width ="50" Height="50" alt="Syndicate of Ministry of Communications" title="syndicate" /> 
            <p><strong>الوصف</strong></p>
        </div>
        <div class="col-sm-10">
            
               <textarea name="desc" cols="70"></textarea>
               
        </div>
    </div>

    <div class="row main-row">
        <div class="col-sm-2 text-center">
            <img src="images/6.png" Width ="50" Height="50" alt="Syndicate of Ministry of Communications" title="syndicate" /> 
            <p><strong>درجة الأهمية</strong></p>
        </div>
        <div class="col-sm-10">
            <div class="row main-row">
                <div class="col-sm-3">
                    <input id="ChkBox1" type="checkbox" />
                            <label for="ChkBox1">عالي جدا</label>
                </div>
                <div class="col-sm-3">
                    <input id="ChkBox2" type="checkbox" />
                    <label for="ChkBox2">عالي</label>
                </div>
                <div class="col-sm-3">
                    <input id="ChkBox3" type="checkbox" />
                    <label for="ChkBox3">متوسط</label>
                </div>
                <div class="col-sm-3">
                    <input id="ChkBox4" type="checkbox" />
                    <label for="ChkBox4">منخفض</label>
                </div>
            </div>
            
        </div>
    </div>

    <div class="row main-row">
        <div class="col-sm-2 text-center">
            <img src="images/7.png" Width ="50" Height="50" alt="Syndicate of Ministry of Communications" title="syndicate" /> 
            <p><strong>سبب الصيانة / التحديث</strong></p>
        </div>
        <div class="col-sm-10">
               <textarea name="desc" cols="70"></textarea>
        </div>
    </div>


    <div class="row main-row">
        <div class="col-sm-2 text-center">
            <img src="images/8.png" Width ="50" Height="50" alt="Syndicate of Ministry of Communications" title="syndicate" /> 
            
            <p><strong>المباني التي ستتأثر</strong></p>
        </div>
        <div class="col-sm-10">
            <div class="row main-row">
                <div class="col-sm-3">
                    <input id="CBox1" type="checkbox" />
                            <label for="CBox1">مبنى المعادي</label>
                        </div>
                <div class="col-sm-3">
                    <input id="CBox2" type="checkbox" />
                    <label for="CBox2">مبنى المهندسين</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox3" type="checkbox" />
                    <label for="CBox3">B 5</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox4" type="checkbox" />
                    <label for="CBox4">B 1</label>
                </div>
            </div>
            
        
        </div>
    </div>

    <div class="row main-row">
        <div class="col-sm-2 text-center">
            <img src="images/5.png" Width ="50" Height="50" alt="Syndicate of Ministry of Communications" title="syndicate" /> 
            <p><strong>الإدارة الفنية المسئولة</strong></p>
        </div>
        <div class="col-sm-10">
               <textarea name="desc" cols="70"></textarea>
        </div>
    </div>

    <%--<div class="row main-row">
        <div class="col-sm-2 text-center">
            <img src="images/5.png" Width ="50" Height="50" alt="Syndicate of Ministry of Communications" title="syndicate" /> 
            <p><strong>التعليقات / الافتراضات / الملاحظات</strong></p>
        </div>
        <div class="col-sm-10">
            <div class="col-sm-12">
               <textarea name="comment" cols="100"></textarea>
            </div>
        
        </div>
    </div>--%>

    <div class="row main-row">
        <div class="col-sm-2 text-center">
            <img src="images/qr-code.png" Width ="50" Height="50" alt="Syndicate of Ministry of Communications" title="syndicate" /> 
            <p><strong>المرفقات </strong></p>
        </div>
        <div class="col-sm-10">
            <div class="col-sm-6">
                <input accept="image/*" type="file" id="imgInp" />
            </div>
               <div class="col-sm-6">
               <img id="blah" width ="100" height ="100" alt="your image" hidden/>
</div>
        </div>
    </div>

    <div class="row main-row">
        <div class="col text-center">
            <div id="saveImg">حفظ</div>
        </div>
    </div> 
        </div>
        </div>
    
    <script src="Scripts/jquery-1.12.4.min.js"></script>
    <script src="Scripts/html2img.js"></script>
</asp:Content>

