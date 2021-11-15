<%@ Page Title="" Language="C#" MasterPageFile="~/AssocMaster.Master" AutoEventWireup="true" CodeBehind="Maintenance-ar.aspx.cs" Inherits="Association.Maintenance" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
   <%--<link rel="stylesheet" type="text/css" href="D:\New_IT_IT\Maintenance Form(34-102021-10-20AM)\datetimepicker-master\jquery.datetimepicker.css"/>--%>
   <%--<link rel="stylesheet" type="text/css" href="D:\New_IT_IT\Maintenance Form(34-102021-10-20AM)\datetimepicker-master"/>--%>


   <script>
       setTimeout(function () {
           $(document).ready(function () {
               $('#saveImg').click(function () {
                   //saveImg
                   $('#imgInp').hide();
                   
                   html2canvas($('body')[0]).then(canvas => {
                       $('#imgInp').show();
                       var a = document.createElement('a');                  
                   a.href = canvas.toDataURL("image/jpeg").replace("image/jpeg", "image/octet-stream");                  
                   n =  new Date();
                   y = n.getFullYear();
                   m = n.getMonth() + 1;
                   d = n.getDate();
                   var date=d+"_" + m + "_" + y+"-";
                   a.download = date+'Maintenance.jpg';
                   //d+ "_" + m + "_" + y+"-"+

                   a.click();
               });

           });

           //window.takeScreenShot = function() {
           //    var textarea = document.getElementById("Testdes");
           //    textarea.style.height = textarea.scrollHeight + "px";
           //    html2canvas(textarea, {
           //        onrendered: function(canvas) {
           //            document.body.appendChild(canvas);
           //            textarea.style.height = "";
           //        },
           //        width: 320,
           //        height: textarea.offsetHeight
           //    });
           //}

           $('#imgInp').change(function () {

               const file = $(this).context.files[0];
               if (file){
                   document.getElementById("blah").src = URL.createObjectURL(file);
                   $("#blah").show();
                   
               }        
           });
       });
       }, 1000);

      
       

       
       
   </script>

    
    <style type="text/css">
         @font-face {
    font-family: Almarai;
    src: url(Fonts/Almarai-Light.ttf);
}

        .auto-style1 {
            width: 227px
        }
        .header-title {
            font-weight: bold;
            font-size: 20px;
            font-family: Almarai;
            color:black;
        
            /*text-decoration: underline;*/
        }

        .normal-title {
            font-weight: bold;
            font-size: 14px;
            font-family: Almarai;
            color:black;
        
            /*text-decoration: underline;*/
        }

        .main-row {
            margin-bottom: 10px;
            /*margin-top:10px;*/
        }
        .ckbox {
           color:black;
          
        }
        .buld-row {
            margin-bottom: 10px;
            direction:ltr;
        }
        /*.lable {
        color:red;
        }*/
       input[type=checkbox]:checked + label {
  color: blue;
  font-style: italic;
 
}

        .datetime-input {
            min-width: 250px;
        } 
    </style>
   

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form_bg" id ="image">
            <div class="row main-row">
        <%--<div class="col text-center">
            <div id="saveImg">طباعة</div>
        </div>--%>
    </div> 
                    <div class="row">
        <div class="col-sm-12 text-center">
            <img id="saveImg" src="images/1.png" Width ="85" Height="75" alt="Syndicate of Ministry of Communications" title="Print Image" />                  
        </div>
        <div class="col-sm-12 text-center">       
             <span class ="header-title "> إخطار بإجراءات  صيانة / تحديث</span>                   
        </div>
        <div class="col-sm-12 text-center">       
             
            <span class ="header-title"> الإدارة المركزية لنظم المعلومات و التحول الرقمي</span>      
        </div>
    </div>


    <div class="row main-row">
        <div class="col-sm-3 text-center">
            <img src="images/2.png" Width ="65" Height="65" /> 
            <p><strong class="normal-title">نوع الصيانة</strong></p>
        </div>
        <div class="col-sm-9">
            <div class="row main-row" style ="margin-top:20px;">
                <div class="col-sm-3">
                    <input id="Checkbox1" type="checkbox"/>
                            <label class="ckbox"  for="Checkbox1">دورية</label>
                </div>
                <div class="col-sm-3">
                    <input id="Checkbox2" type="checkbox" />
                            <label class="ckbox" for="Checkbox2">تحديث</label>
                </div>
                <div class="col-sm-3">
                    <input id="Checkbox3" type="checkbox" />
                    <label class="ckbox" for="Checkbox3">عطل</label>
                </div>
                <div class="col-sm-3">
                    <input id="Checkbox4" type="checkbox" />
                    <label class="ckbox" for="Checkbox4">استباقية</label>
                </div>
            </div>
           
        </div>
    </div>

    <div class="row main-row">
        <div class="col-sm-3 text-center">
            <img src="images/3.png" Width ="65" Height="65"/> 
            <p><strong class="normal-title">توقيت الصيانة / التحديث</strong></p>
        </div>
        <div class="col-sm-9">
            <div class="row main-row">
                <div class="col-md-5">
                    <label class="ckbox" for="txtMemb_Date_Contract">التاريخ من: </label>
                    <div class="input-group datetime">
                        <input id="Txtdatefrom" class="text-right datetime-input" style="color:black" dir="ltr" placeholder="التاريخ من "CssClass="form-control" type="text" />
                        <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                    </div>
                </div>
                <div class="col-md-5">
                    <label class="ckbox" for="txtMemb_Date_Contract">التاريخ إلي:</label>
                    <div class="input-group datetime">
                        <input id="TxtdateTo"class="text-right datetime-input" style="color:black" dir="ltr" placeholder="التاريخ إلي "CssClass="form-control" type="text" />
                        <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                    </div>
                </div>
            </div>
            
        </div>
    </div>


    <div class="row main-row">
        <div class="col-sm-3 text-center">
            <img src="images/4.png" Width ="70" Height="70" /> 
            <p><strong class="normal-title">الخدمات التي ستتأثر</strong></p>
        </div>
        <div class="col-sm-9">
            <div class="row main-row">
                <div class="col-sm-4">
                    <input id="Checkbox5" type="checkbox" />
                        <label class="ckbox" for="Checkbox5">خدمات التأمين السيبراني</label>
                </div>
                <div class="col-sm-4">
                    <input id="Checkbox6" type="checkbox" />
                    <label class="ckbox" for="Checkbox6">الخدمات التليفونية</label>
                </div>
                <div class="col-sm-4">
                    <input id="Checkbox7" type="checkbox" />
                    <label class="ckbox" for="Checkbox7">خدمات الشبكات اللاسلكية</label>
                </div>
                <div class="col-sm-4">
                    <input id="Checkbox9" type="checkbox" />
                    <label class="ckbox" for="Checkbox9">خدمات الشبكات السلكية</label>
                </div>

                <div class="col-sm-4">
                    <input id="Checkbox10" type="checkbox" />
                        <label class="ckbox" for="Checkbox10">خدمات التيار الكهربائي</label><br />
                </div>
                <div class="col-sm-4">
                    <input id="Checkbox11" type="checkbox" />
                        <label class="ckbox" for="Checkbox11">أجهزة الحواسب الشخصية</label>
                </div>
                <div class="col-sm-4">
                    <input id="Checkbox12" type="checkbox" />
                    <label class="ckbox" for="Checkbox12">أجهزة الخوادم المركزية</label>
                </div>
                <div class="col-sm-4">
                    <input id="Checkbox13" type="checkbox" />
                    <label class="ckbox" for="Checkbox13">التطبيقات</label>
                </div>
                <div class="col-sm-4">
                    <input id="Checkbox14" type="checkbox" />
                    <label class="ckbox" for="Checkbox14">البريد الالكتروني</label>
                </div>

                <div class="col-sm-4">
                    <input id="Checkbox15" type="checkbox" />
                    <label class="ckbox" for="Checkbox15">خدمات أخرى</label>
                </div>
            </div>

            
            
        </div>
    </div>

    <div class="row main-row">
        <div class="col-sm-3 text-center">
            <img src="images/5.png" Width ="50" Height="50" /> 
            <p><strong class="normal-title">الوصف</strong></p>
        </div>
        <div class="col-sm-9">                      
            <div contenteditable="true" style="word-wrap: normal; font-family:'Arial (Body CS)';font-weight:bold; color:black; font-size:16px;   text-align:right;border:1px solid gray;background:white;width:700px;"></div>             
        </div>
    </div>

    <div class="row main-row">
        <div class="col-sm-3 text-center">
            <img src="images/6.png" Width ="50" Height="50"  /> 
            <p><strong class="normal-title">درجة الأهمية</strong></p>
        </div>
        <div class="col-sm-9">
            <div class="row main-row">
                <div class="col-sm-3">
                    <input id="ChkBox1" type="checkbox" />
                            <label class="ckbox" for="ChkBox1">عالي جدا</label>
                </div>
                <div class="col-sm-3">
                    <input id="ChkBox2" type="checkbox" />
                    <label class="ckbox" for="ChkBox2">عالي</label>
                </div>
                <div class="col-sm-3">
                    <input id="ChkBox3" type="checkbox" />
                    <label class="ckbox" for="ChkBox3">متوسط</label>
                </div>
                <div class="col-sm-3">
                    <input id="ChkBox4" type="checkbox" />
                    <label class="ckbox" for="ChkBox4">منخفض</label>
                </div>
            </div>
            
        </div>
    </div>

    <div class="row main-row">
        <div class="col-sm-3 text-center">
            <img src="images/7.png" Width ="50" Height="50"  /> 
            <p><strong class="normal-title">سبب الصيانة / التحديث</strong></p>
        </div>
        <div class="col-sm-9">
               <div contenteditable="true" style="word-wrap: normal; font-family:'Arial (Body CS)';font-weight:bold; color:black; font-size:16px;    text-align:right;border:1px solid gray;background:white;width:700px;"></div>
        </div>
    </div>


    <div class="row main-row">
        <div class="col-sm-3 text-center">
            <img src="images/8.png" Width ="70" Height="70" /> 
            
            <p><strong class="normal-title">المباني التي ستتأثر</strong></p>
        </div>
        <div class="col-sm-9">
            <div class="row main-row">
                <div class="col-sm-3">
                    <input id="CBox1" type="checkbox" />
                            <label class="ckbox" dir="ltr">MCIT-B1</label>
                        </div>
                <div class="col-sm-3">
                    <input id="CBox2" type="checkbox" dir="ltr"/>
                    <label class="ckbox" for="CBox2"dir="ltr">MCIT-B2 </label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox5" type="checkbox" />
                    <label class="ckbox" for="CBox5"dir="ltr">MCIT-B5</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox10" type="checkbox" />
                    <label class="ckbox" for="CBox10"dir="ltr">MCIT-B115</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox6" type="checkbox" />
                    <label class="ckbox" for="CBox6"dir="ltr">MCIT-B145*</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox11" type="checkbox" />
                    <label class="ckbox" for="CBox11"dir="ltr">MCIT-Maadi </label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox12" type="checkbox" />
                    <label class="ckbox" for="CBox12"dir="ltr">MCIT-Muhandisin</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox31" type="checkbox" />
                    <label class="ckbox" for="CBox31"dir="ltr">MCIT-Ataba</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox4" type="checkbox" />
                    <label class="ckbox" for="CBox4"dir="ltr">NTRA-B4</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox29" type="checkbox" />
                    <label class="ckbox" for="CBox29"dir="ltr">NTRA-B145</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox22" type="checkbox" />
                    <label class="ckbox" for="CBox22"dir="ltr">NTRA-Nasr City</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox21" type="checkbox" />
                    <label class="ckbox" for="CBox21"dir="ltr">NTRA-Giza</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox23" type="checkbox" />
                    <label class="ckbox" for="CBox23"dir="ltr">NTRA-Asyut</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox24" type="checkbox" />
                    <label class="ckbox" for="CBox24"dir="ltr">NTRA-Ismailia</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox25" type="checkbox" />
                    <label class="ckbox" for="CBox25"dir="ltr">NTRA-Tanta</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox26" type="checkbox" />
                    <label class="ckbox" for="CBox26"dir="ltr">NTRA-Alexandria</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox27" type="checkbox" />
                    <label class="ckbox" for="CBox27"dir="ltr">NTRA-Ain Shams</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox28" type="checkbox" />
                    <label class="ckbox" for="CBox28"dir="ltr">NTRA-Mubarak(Alex)</label>
                </div>
                
                
                <div class="col-sm-3">
                    <input id="CBox8" type="checkbox" />
                    <label class="ckbox" for="CBox8"dir="ltr">ITI-B147</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox15" type="checkbox" />
                    <label class="ckbox" for="CBox15"dir="ltr">ITI-Aswan</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox16" type="checkbox" />
                    <label class="ckbox" for="CBox16"dir="ltr">ITI-Mansoura</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox17" type="checkbox" />
                    <label class="ckbox" for="CBox17"dir="ltr">ITI-Monofia</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox18" type="checkbox" />
                    <label class="ckbox" for="CBox18"dir="ltr">ITI-Qena</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox19" type="checkbox" />
                    <label class="ckbox" for="CBox19"dir="ltr">ITI-Sohag</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox20" type="checkbox" />
                    <label class="ckbox" for="CBox20"dir="ltr">ITI-Menya</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox32" type="checkbox" />
                    <label class="ckbox" for="CBox32"dir="ltr">AI-B51</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox33" type="checkbox" />
                    <label class="ckbox" for="CBox33"dir="ltr">AI-Alex</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox30" type="checkbox" />
                    <label class="ckbox" for="CBox30"dir="ltr">IDSC-El Alamein</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox34" type="checkbox" />
                    <label class="ckbox" for="CBox34"dir="ltr">IDSC-Downtown</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox9" type="checkbox" />
                    <label class="ckbox" for="CBox9"dir="ltr">NTI-B148</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox7" type="checkbox" />
                    <label class="ckbox" for="CBox7"dir="ltr">ITIDA-B121</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox14" type="checkbox" />
                    <label class="ckbox" for="CBox14"dir="ltr">AIC–B51</label>
                </div>
                <div class="col-sm-3">
                    <input id="CBox3" type="checkbox" />
                    <label class="ckbox" for="CBox3"dir="ltr">Cultnat-B3</label>
                </div>
            </div>
            
        
        </div>
    </div>

    <div class="row main-row">
        <div class="col-sm-3 text-center">
            <img src="images/9.png" Width ="80" Height="80" /> 
            <p><strong class="normal-title">الإدارة الفنية المسئولة</strong></p>
        </div>
        <div class="col-sm-9">
               <div contenteditable="true" style="word-wrap: normal; font-family:'Arial (Body CS)';font-weight:bold; color:black; font-size:16px; text-align:right;border:1px solid gray;background:white;width:700px;"></div>
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
        <div class="col-sm-3 text-center">
            <a href="https://www.qr-code-generator.com/solutions/vcard-qr-code/" target ="_blank">
            <img src="images/qr-code.png" Width ="70" Height="70"/> 
            <p><strong class="normal-title">QR Code</strong></p>
        </div>
        <div class="col-sm-9">
            <div class="col-sm-6">
                <input accept="image/*" type="file" id="imgInp" />
            </div>
               <div class="col-sm-6">
                   <img id="blah" width ="100" height ="100" alt="your image" hidden/>
               </div>
        </div>
    </div>
            
    <%--<div class="row main-row">
        <div class="col text-center">
            <div id="saveImg">حفظ</div>
        </div>
    </div> --%>
        </div>
        </div>
   
     
    </a>
   
     
</asp:Content>

