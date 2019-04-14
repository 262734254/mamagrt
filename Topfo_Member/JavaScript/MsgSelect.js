
//.入口参数

	var topCatForm = Form1.listBig;
	var secondCatForm = Form1.listSmall;
	
	var topCatArr = new Array();        
	var PtopCatArr= new Array();
	var EtopCatArr= new Array();
	
	
	//下拉列表的起始索引
	var beginIndex = 1;
	    
	if(beginIndex > 1) beginIndex = 1;

	 

	var topCat;
	var sCat;

	//top category methods
	function TopCategory(id, title)
		{
		this.id=id;
		this.title = title;
		
		this.childCategorys = new Array();
		this.childOptions = new Array();
		this.addChildCategory = addChildCategory;
		this.option = new Option(this.title, this.id);
		this.getChildOptions = getChildOptions;
	}   
		//category methods
	function Category(parent, id, title) 
	{
		this.parent=parent;
		this.id=id;
		this.title = title;
		this.childCategorys = new Array();
		this.childOptions = new Array();
		this.addChildCategory = addChildCategory;
		this.option = new Option(this.title, this.id);
		this.getChildOptions = getChildOptions;
		parent.addChildCategory(this);
	}

	function getChildOptions() {
		return this.childOptions;
	}

//	function getChildOptions() {
//		return this.childOptions;
//	}

	function addChildCategory(category)
		{
		this.childCategorys = this.childCategorys.concat(category);
		this.childOptions = this.childOptions.concat(category.option);
	}

	function initTopCategoryForm()
	{
		var size = topCatArr.length;
		for(var i=0;i<size;i++){
			topCatForm.options[i + beginIndex] = topCatArr[i].option;      		
		}
		changeTopCategory(); 
	}


	function onChangeTopCategory()
	{
		changeTopCategory();
	}
	

	function changeTopCategory()
	{
		if (topCatForm.selectedIndex == -1 || (topCatForm.selectedIndex == 0 && beginIndex == 1)) {
			if(beginIndex == 1)
				topCatForm.options[0].selected=true;
			secondOptions = secondCatForm.options;
			var len = secondCatForm.options.length;
			for (var i=len-1; i > beginIndex - 1; i--){
			secondCatForm.options[i]=null;
			}                                        
		}
		else {        	
			var secondOptions = topCatArr[topCatForm.selectedIndex - beginIndex].getChildOptions();
			var len = secondCatForm.options.length;
			for (var i=len-1; i > beginIndex - 1; i--){
					secondCatForm.options[i]=null;
			}                
			for (var i=0;i<secondOptions.length;i++) {
					secondCatForm.options[i + beginIndex] = secondOptions[i];
			}
		}  
		if(beginIndex == 1)
			secondCatForm.options[0].selected=true;

	}

	function getSmallID(){
	if(typeof(Form1.listSmall) == ""){
		if(Form1.listSmall.selectedIndex >= beginIndex){
			return Form1.listSmall.value;
		}
		else if(Form1.listSmall.length > beginIndex){
			return "";
		}
		if(Form1.listBig.selectedIndex >= beginIndex){
			return Form1.listBig.value;
		}
	}
	return "";
	}

	function getBigID(){
	if(typeof(Form1.listBig) == "object"){
		if(Form1.listBig.selectedIndex >= beginIndex){
			return Form1.listBig.value;
		}
	}
	return "";
	}
	

	function insertIntoFrom(){	   
		//将列表的信息全部放置入列表之中			
		var SmallID=getSmallID();
		document.Form1.hideSmall.value = SmallID;		

		var BigID=getBigID();	  
		document.Form1.hideBig.value = BigID;					

	}

	function selectBigID(BigID,SmallID) {
		for(var i=0;i<topCatForm.length;i++) {
			if (topCatForm.options[i].value==BigID) {
				topCatForm.options[i].selected=true;
				changeTopCategory();
				break;
			}
		}
		for(var i=0;i<secondCatForm.length;i++) {
			if (secondCatForm.options[i].value==SmallID) {
				secondCatForm.options[i].selected=true;
				break;
			}
		}
	}

var TheTopCatFormKey = document.Form1.listBig;

if (TheTopCatFormKey != null)
{
	topCat = new TopCategory('100', '网站常见问题')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat,'101','网站出错')
	sCat = new Category(topCat,'102','不能访问')
	sCat = new Category(topCat,'103','速度缓慢')
	sCat = new Category(topCat,'104','服务态度')
	sCat = new Category(topCat,'105','订单咨询')
	sCat = new Category(topCat,'106','其他')


	
		
	topCat = new TopCategory('200','网站栏目建议')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat,'201','网站首页')
	sCat = new Category(topCat,'202','会员管理系统')
	sCat = new Category(topCat,'203','政府招商')
	sCat = new Category(topCat,'204','投资频道')
	sCat = new Category(topCat,'205','融资频道')
	sCat = new Category(topCat,'206','创业频道')
	sCat = new Category(topCat,'207','商机频道')
	sCat = new Category(topCat,'208','资讯频道')
	sCat = new Category(topCat,'209','分站频道')
	sCat = new Category(topCat,'210','创富俱乐部')
	sCat = new Category(topCat,'211','成功案例')
	sCat = new Category(topCat,'212','精英人物')
	sCat = new Category(topCat,'213','专家咨询')
	sCat = new Category(topCat,'214','会展专区')
	sCat = new Category(topCat,'215','产权交易')
	sCat = new Category(topCat,'216','招标投标')
	sCat = new Category(topCat,'217','特色服务')
	sCat = new Category(topCat,'218','联盟合作')
	sCat = new Category(topCat,'219','网络名片')
	sCat = new Category(topCat,'220','创富论坛')
	sCat = new Category(topCat,'221','网络百事通')

	topCat = new TopCategory('300','网站功能建议')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat,'301','会员注册')
	sCat = new Category(topCat,'302','会员登录')
	sCat = new Category(topCat,'303','网站交易')
	sCat = new Category(topCat,'304','购卡充值')
	sCat = new Category(topCat,'305','奖励积分')
	sCat = new Category(topCat,'306','信息发布')
	sCat = new Category(topCat,'307','信息管理')
	sCat = new Category(topCat,'308','信息收藏')
	sCat = new Category(topCat,'309','内容搜索')
	sCat = new Category(topCat,'310','页面订制')
	sCat = new Category(topCat,'311','搜索订阅')
	sCat = new Category(topCat,'312','站内短信')
	sCat = new Category(topCat,'313','资料修改')
	sCat = new Category(topCat,'314','密码找回')
	sCat = new Category(topCat,'315','名片管理')
	sCat = new Category(topCat,'316','帐户信息')
	sCat = new Category(topCat,'317','贵宾卡申请')
	
	
	topCat = new TopCategory('400','分站需求反馈')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat,'401','分站页面')
	sCat = new Category(topCat,'402','分站功能')
	sCat = new Category(topCat,'403','分站业务')
	sCat = new Category(topCat,'404','分站培训')
	sCat = new Category(topCat,'405','分站财务')
	
	topCat = new TopCategory('500','虚假信息投诉')

	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat,'501','招商信息')
	sCat = new Category(topCat,'502','投资信息')
	sCat = new Category(topCat,'503','融资信息')
	sCat = new Category(topCat,'504','创业信息')
	sCat = new Category(topCat,'505','商机信息')
	sCat = new Category(topCat,'506','其他信息')

	topCat = new TopCategory('600','网络业务咨询和申报')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat,'601','创富卡')
	sCat = new Category(topCat,'602','贵宾卡')
	sCat = new Category(topCat,'603','需求发布')
	sCat = new Category(topCat,'604','网络广告')
	sCat = new Category(topCat,'605','网络名片')
	sCat = new Category(topCat,'606','对口中介')
	sCat = new Category(topCat,'607','网站建设')
	sCat = new Category(topCat,'608','特色服务申报')
	sCat = new Category(topCat,'609','其他')
	
	topCat = new TopCategory('700','专业服务咨询')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat,'701','“标的”式招商委托')
	sCat = new Category(topCat,'702','“标的”式融资委托')
	sCat = new Category(topCat,'703','产业规划与产业招商')
	sCat = new Category(topCat,'704','成立驻地招商代表处')
	sCat = new Category(topCat,'705','地区投资环境评测')
	sCat = new Category(topCat,'706','立体媒体宣传')
	sCat = new Category(topCat,'707','融资咨询')
	sCat = new Category(topCat,'708','投资咨询')
	sCat = new Category(topCat,'709','其他')
	
	topCat = new TopCategory('800','其他问题')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat,'801','其他')
		
	

	initTopCategoryForm();
	var BigID;
	var SmallID;
	BigID =document.Form1.hideBig.value;
	SmallID=document.Form1.hideBig.value;
	selectBigID(BigID,SmallID)	
}	
