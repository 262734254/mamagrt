/*此验证库来源网络、略作修改、还有很多不了解的地方
* 使用说明:
1.引用类库文件
<script src="jscript/jquery.js" type="text/javascript"></script>
<script src="jscript/jquery.validate.js" type="text/javascript"></script>
2.将三个状态图标复制到你的项目中,并修改变量imgPath
dedefault.gif:要求验证的控件默认显示的图标
deok.gif:验证通过后显示的图标
deerr.gif 验证失败后显示的图标
3.在要验证的控件中加入标记 validatetype="...",即表示启用了验证,非常方便
默认情况下,错误提示信息是在当鼠标移至图标时提示,这主要是考虑在很多时候,我们的表单并没有足够的空间让我们来显示,
如果有足够的空间,你可以启用另一个标记: showError="true",这样,错误信息将在此控件后面直接显示出来.
可使用的验证类型:    
Email: 电子邮件,
ChineseName: 用户名称,
EnglishName: 英文名称,
UserName: 验证用户名,字母开头，允许5-16字节，允许字母数字下划线,
Password: 只能输入6-20个字母、数字、下划线
Tele: 电话号码,
Postcode: 邮政编码为6位数字,
Integer: 正整数,
Float: 正浮点数,
Url: url地址,
Mobile: 手机号码,
Address: 地址
Compare: 验证两次输入的密码是否一致
AjaxVerify:通过后台验证,一般用来检查用户名是否存在

//新增
NotNull:不能为空
_Float:浮点数
            
4.为提交的按钮加个onclientclick="return validate();",先验证再执行后台代码
<asp:Button ID="btnAdd" runat="server" Text="确定" onclientclick="return validate();" OnClick="btnAdd_Click" />
*/
//图片文件的存放目录
var imgPath = "/images/";//

//给定需要验证的input添加 needValidate='true' 的属性对，然后选择他们，添加blur的事件函数。
$(function() {
    //先为每个要验证的控件加上蓝色图标
    $("input[validatetype]").each(function(index) {
        //获取验证的类型,如果没有设置,默认为邮箱
        var validateType = $("#" + this.id).attr("validateType");
        //先判断要不要直接显示错误,如果需要,则创建Error层
        var b = $("#" + this.id).attr("showError");
        if (b == "true") {
            if (document.getElementById("#" + this.id + validateType + "_error") == null) {
                var oError = $("<span style=\"vertical-align: top\" id=\"" + this.id + validateType + "_error\"></span>");
                oError.insertAfter("#" + this.id);
            }
        }
        //加入Img层
        if (document.getElementById("#" + this.id + "_img") == null) {
            var oImg = $("<span style=\"vertical-align: bottom\" id=\"" + this.id + validateType + "_img\"></span>");
            oImg.insertAfter("#" + this.id);
        }
        //初始化
        $("#" + this.id + validateType + "_img").html("<img src='" + imgPath + "dedefault.gif'/>");
        $("#" + this.id + validateType + "_img").attr("title", "");
    });
    //然后为他们指定失去焦点事件
    $("input[validatetype]").blur(function() {
        if (FieldValidate(this))//首先客户端验证
        {
            var validateType = $("#" + this.id).attr("validateType");
            if (validateType == "")
                validateType = "Email";
            var allowNull = $("#" + this.id).attr("allowNull");
            //如果设置了允许为空字段,则将bAllowNull设置为true
            var bAllowNull = false;
            if (allowNull) {
                bAllowNull = allowNull.toLowerCase() == "true" ? true : false;
            }

            if (bAllowNull && this.value == "") {
                $('#' + this.id + validateType + '_img').html("<img src='" + imgPath + "dedefault.gif'/>");
            }
            else {
                $('#' + this.id + validateType + '_img').html("<img src='" + imgPath + "deok.gif'/>");
                $('#' + this.id + validateType + '_img').attr("title", "");
            }
        }
    });
});

/*
对表弟中的控件进行输入验证,如果验证通过,返回true,否则,给出错误提示,并返回false
参数 ctl :为要验证的控件
*/
function FieldValidate(ctl) {
    var Email = /\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/; //电子邮件
    var ChineseName = /^[\u4E00-\u9FA5]+$/;  //用户名称
    var EnglishName = /^[a-zA-Z\s]{1,50}$/; //英文名称
    var UserName = /^[a-zA-Z0-9_]{4,20}$/; //验证用户名必须5-20个字符
    var Password = /\w{5,20}/;  //至少输入5-20个字符
    var Tele = /^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$/; //电话号码
    var Postcode = /[1-9]\d{5}(?!\d)/; //邮政编码为6位数字
    var Integer = "^\\d+$"; //非负整数
    var Float = "^\\d+(\\.\\d+)?$"; //非负浮点数
    var Url = /http(s)?:\/\/([\w-]+\.)+[\w-]+(\/[\w-.\/?%&=]*)?/; //url地址
    var Mobile = /^1\d{10}$/; //手机号码
    var Address = /^[\u4E00-\u9FA5\d]+$///地址
    var AjaxVerify = /^[a-zA-Z][a-zA-Z0-9_]{5,15}$/; //验证用户名,字母开头，允许5-16字节，允许字母数字下划线

    //新增 验证类型
   var NotNull=/^.+$/;    //不能为空
   var _Float = "^[-]?\\d+(\\.\\d+)?$";   //浮点数
   var bankid=/^[0-9]{19}$/;
   //新增 错误信息的定义
   var NotNull_error="不能为空,请您填写!";
   var _Float_error = "您必须输入浮点数!";
var bankid_error = "您必须输入19位整数!";
    //错误信息的定义
    var Email_error = "邮箱有误!示例:hjl@vip.qq.com";
    var ChineseName_error = "必须输入中文名字!";
    var EnglishName_error = "必须输入英文名字!";
    var UserName_error = "联系人必须4-20个字符!";
    var Password_error = "密码必须5-20个字符!";
    var Tele_error = "电话号码格式有误!";
    var Postcode_error = "邮编格式有误!";
    var Integer_error = "您必须输入非负整数!";
    var Float_error = "您必须输入非负浮点数!";
    var Url_error = "网址格式有误!";
    var Mobile_error = "手机号码格式有误!";
    var Address_error = "地址格式有误!";
    var Compare_error = "您两次输入的密码不相同!";
    var validateType = $("#" + ctl.id).attr("validateType");
    var allowNull = $("#" + ctl.id).attr("allowNull");
   

    //如果设置了允许为空字段,则将bAllowNull设置为true
    var bAllowNull = false;
    if (allowNull) {
        bAllowNull = allowNull.toLowerCase() == "true" ? true : false;
        if (bAllowNull && ctl.value == "") {
            return true;
        }
    }
    //进行验证
    if (validateType == "Compare") {//如果是要进行比较的
        var newPass = $("#" + ctl.id).attr("CompareControl");
        var ctrNewPass = $("*[id$=" + newPass + "]")[0];
        if (ctrNewPass.value == ctl.value) {
            //验证通过,将图标的错误信息去掉
            $('#' + ctl.id + validateType + '_img').attr("title", "");
            var b = $("#" + ctl.id).attr("showError");
            if (b == "true")
                $("#" + ctl.id + validateType + "_error").html("");
            return true;
        }
        else {
            //验证失败,将图标换成错误图标,并加上错误提示
            $('#' + ctl.id + validateType + '_img').html("<img src='" + imgPath + "deerr.gif' /><span style='color:Red;text-align:left;'>"+eval(validateType + '_error')+"</span>").attr("title", eval(validateType + '_error'));
            var b = $("#" + ctl.id).attr("showError");
            if (b == "true") {
                $("#" + ctl.id + validateType + "_error").html(eval(validateType + '_error')).attr("style", "color:red;");
            }
            return false;
        }
    }
    else if (validateType == "AjaxVerify") {//如果是要调用后台的
        var BehideFile = $("#" + ctl.id).attr("behidefile");
        $('#' + ctl.id + validateType + '_img').html("<img src='" + imgPath + "loading.gif' />").attr("title", "正在从进行验证...");
        var b = $("#" + ctl.id).attr("showError");
        if (b == "true") {
            $("#" + ctl.id + validateType + "_error").html("正在从进行验证...").attr("style", "color:green;");
        }
        $.get(BehideFile, ctl.value, function(data) {
            if (data.substring(0, 1) == "1") {
                //验证通过,将图标的错误信息去掉
                $('#' + ctl.id + validateType + '_img').html("<img src='" + imgPath + "deok.gif' />").attr("title", "");
                var b = $("#" + ctl.id).attr("showError");
                if (b == "true")
                    $("#" + ctl.id + validateType + "_error").html("");
                return true;
            }
            else {
                //验证失败,将图标换成错误图标,并加上错误提示
                $('#' + ctl.id + validateType + '_img').html("<img src='" + imgPath + "deerr.gif' />").attr("title", "此用户名称已经存在.");
                var b = $("#" + ctl.id).attr("showError");
                if (b == "true")
                    $("#" + ctl.id + validateType + "_error").html(eval(validateType + '_error')).attr("style", "color:red;");
                return false;
            }
        });
    }
    else {
        if (ctl.value.match(eval(validateType))) {
            //验证通过,将图标的错误信息去掉
            $('#' + ctl.id + validateType + '_img').attr("title", "");
            var b = $("#" + ctl.id).attr("showError");
            if (b == "true")
                $("#" + ctl.id + validateType + "_error").html("");
            return true;
        }
        else {
           //验证失败,将图标换成错误图标,并加上错误提示
            $('#' + ctl.id + validateType + '_img').html("<img src='" + imgPath + "deerr.gif' /><span style='color:Red;text-align:left;'>"+eval(validateType + '_error')+"</span>").attr("title", eval(validateType + '_error'));
            var b = $("#" + ctl.id).attr("showError");
            if (b == "true") {
                $("#" + ctl.id + validateType + "_error").html(eval(validateType + '_error')).attr("style", "color:red;");
            }
            return false;
        }
    }
}







function validate() {
    var isPassed = true;
    $("input[validatetype]").each(function(i) {
        var validateType = $("#" + this.id).attr("validateType");
        if (validateType != "AjaxVerify") {
            if (!FieldValidate(this)) {
                isPassed = false;
                
            }
            
        }
    });
    if(isPassed){
         $(".alert").hide();
   }else{
         $("#main").append("<div class=\"alert\">页面输入数据格式不正确，请检查重新输入！</div>");
         $(".alert").fadeIn("slow");
         setTimeout(function(){
            $(".alert").fadeOut("slow",function(){$(this).remove();});
         },3000);
   }
    return isPassed;
}