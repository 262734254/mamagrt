//.入口参数
	var topCatForm = Form1.topCatFormKey;
	var secondCatForm = Form1.secondCatFormKey;
	
	var PtopCatForm = Form1.PtopCatFormKey;
	var PsecondCatForm = Form1.PsecondCatFormKey;	

	var EtopCatForm = Form1.EtopCatFormKey;
	var EsecondCatForm = Form1.EsecondCatFormKey;	
	
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
	
	
	////
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

//	function addChildCategory(category)
//		{
//		this.childCategorys = this.childCategorys.concat(category);
//		this.childOptions = this.childOptions.concat(category.option);
//	}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	function initTopCategoryForm()
	{
		var size = topCatArr.length;
		for(var i=0;i<size;i++){
			topCatForm.options[i + beginIndex] = topCatArr[i].option;      		
		}
		changeTopCategory(); 
	}

	///
	function onChangeTopCategory()
	{
		changeTopCategory();
	}
	
///
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

	
	///////

	function getIndustryMID(){
	if(typeof(Form1.secondCatFormKey) == "object"){
		if(Form1.secondCatFormKey.selectedIndex >= beginIndex){
			return Form1.secondCatFormKey.value;
		}
		else if(Form1.secondCatFormKey.length > beginIndex){
			return "";
		}
		if(Form1.topCatFormKey.selectedIndex >= beginIndex){
			return Form1.topCatFormKey.value;
		}
	}
	return "";
	}


/////////////////////////////
	function getIndustryBID(){
	if(typeof(Form1.topCatFormKey) == "object"){
		if(Form1.topCatFormKey.selectedIndex >= beginIndex){
			return Form1.topCatFormKey.value;
		}
	}
	return "";
	}
	

///////////////////////////////////////////////////////////////
	function insertIntoFrom(){	   
		//将列表的信息全部放置入列表之中			
		var IndustryMID=getIndustryMID();		
		document.Form1.hideIndustryM.value = IndustryMID;		

		var IndustryBID=getIndustryBID();	  
		document.Form1.hideIndustryB.value = IndustryBID;					

	}
//////////////

	function selectIndustryBID(IndustryBID,IndustryMID) {
		for(var i=0;i<topCatForm.length;i++) {
			if (topCatForm.options[i].value==IndustryBID) {
				topCatForm.options[i].selected=true;
				changeTopCategory();
				break;
			}
		}
		for(var i=0;i<secondCatForm.length;i++) {
			if (secondCatForm.options[i].value==IndustryMID) {
				secondCatForm.options[i].selected=true;
				break;
			}
		}
	}


	
///////////////////////////////////////////
var TheTopCatFormKey = document.Form1.topCatFormKey;

if (TheTopCatFormKey != null)
{	
	topCat = new TopCategory('R', '投资技术项目')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '83', '农业')
	sCat = new Category(topCat, '84', '服饰')
	sCat = new Category(topCat, '85', '生物')
	sCat = new Category(topCat, '86', '安全防护')
	sCat = new Category(topCat, '87', '食品饮料')
	sCat = new Category(topCat, '88', '电子电工')
	sCat = new Category(topCat, '89', '印刷、出版')
	sCat = new Category(topCat, '90', '纺织皮革')
	sCat = new Category(topCat, '91', '环保')
	sCat = new Category(topCat, '92', '玩具')
	sCat = new Category(topCat, '93', '能源')      	 
	sCat = new Category(topCat, '94', '建筑业')
	sCat = new Category(topCat, '95', '通讯')
	sCat = new Category(topCat, '96', '交通运输')
	sCat = new Category(topCat, '97', '工业用品')
	sCat = new Category(topCat, '98', '商业服务')
	sCat = new Category(topCat, '99', '家居用品')
	sCat = new Category(topCat, '100', '化工')
	sCat = new Category(topCat, '101', '印刷出版')
	sCat = new Category(topCat, '102', '家用电器')
	sCat = new Category(topCat, '103', '医药健康')
	sCat = new Category(topCat, '104', '汽摩及配件')
	sCat = new Category(topCat, '105', '机器机械')
	sCat = new Category(topCat, '106', '计算机与软件')
	sCat = new Category(topCat, '107', '互联网')
	sCat = new Category(topCat, '108', '工艺礼品')
	sCat = new Category(topCat, '109', '运动休闲')
	sCat = new Category(topCat, '110', '冶金矿产')
	sCat = new Category(topCat, '111', '办公、文教')
	sCat = new Category(topCat, '112', '房地产')
	
	topCat = new TopCategory('R', '融资技术项目')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '83', '农业')
	sCat = new Category(topCat, '84', '服饰')
	sCat = new Category(topCat, '85', '生物')
	sCat = new Category(topCat, '86', '安全防护')
	sCat = new Category(topCat, '87', '食品饮料')
	sCat = new Category(topCat, '88', '电子电工')
	sCat = new Category(topCat, '89', '印刷、出版')
	sCat = new Category(topCat, '90', '纺织皮革')
	sCat = new Category(topCat, '91', '环保')
	sCat = new Category(topCat, '92', '玩具')
	sCat = new Category(topCat, '93', '能源')      	 
	sCat = new Category(topCat, '94', '建筑业')
	sCat = new Category(topCat, '95', '通讯')
	sCat = new Category(topCat, '96', '交通运输')
	sCat = new Category(topCat, '97', '工业用品')
	sCat = new Category(topCat, '98', '商业服务')
	sCat = new Category(topCat, '99', '家居用品')
	sCat = new Category(topCat, '100', '化工')
	sCat = new Category(topCat, '101', '印刷出版')
	sCat = new Category(topCat, '102', '家用电器')
	sCat = new Category(topCat, '103', '医药健康')
	sCat = new Category(topCat, '104', '汽摩及配件')
	sCat = new Category(topCat, '105', '机器机械')
	sCat = new Category(topCat, '106', '计算机与软件')
	sCat = new Category(topCat, '107', '互联网')
	sCat = new Category(topCat, '108', '工艺礼品')
	sCat = new Category(topCat, '109', '运动休闲')
	sCat = new Category(topCat, '110', '冶金矿产')
	sCat = new Category(topCat, '111', '办公、文教')
	sCat = new Category(topCat, '112', '房地产')

	initTopCategoryForm();
	var IndustryBID;
	var IndustryMID;
	IndustryBID =document.Form1.hideIndustryB.value;
	IndustryMID=document.Form1.hideIndustryM.value;
	selectIndustryBID(IndustryBID,IndustryMID)	
}	
