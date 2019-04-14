//.入口参数
	var topCatForm = document.forms["Form1"].topCatFormKey;
	var secondCatForm = document.forms["Form1"].secondCatFormKey;
	
	var PtopCatForm = document.forms["Form1"].PtopCatFormKey;
	var PsecondCatForm = document.forms["Form1"].PsecondCatFormKey;	

	var EtopCatForm = document.forms["Form1"].EtopCatFormKey;
	var EsecondCatForm = document.forms["Form1"].EsecondCatFormKey;	
	
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
	if(typeof(document.forms["Form1"].secondCatFormKey) == "object"){
		if(document.forms["Form1"].secondCatFormKey.selectedIndex >= beginIndex){
			return document.forms["Form1"].secondCatFormKey.value;
		}
		else if(document.forms["Form1"].secondCatFormKey.length > beginIndex){
			//return "00001"; modify by kevin 11-23
			return "";
		}
		if(document.forms["Form1"].topCatFormKey.selectedIndex >= beginIndex){
			return document.forms["Form1"].topCatFormKey.value;
		}
	}
	//return "00001"; modify by kevin 11-23
	return "";
	}


/////////////////////////////
	function getIndustryBID(){
	if(typeof(document.forms["Form1"].topCatFormKey) == "object"){
		if(document.forms["Form1"].topCatFormKey.selectedIndex >= beginIndex){
			return document.forms["Form1"].topCatFormKey.value;
		}
	}
	return "";
	}
	

///////////////////////////////////////////////////////////////
	function insertIntoFrom(){	   
		//将列表的信息全部放置入列表之中			
		var IndustryMID=getIndustryMID();		
		document.forms["Form1"].hideIndustryM.value = IndustryMID;		

		var IndustryBID=getIndustryBID();	  
		document.forms["Form1"].hideIndustryB.value = IndustryBID;					

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
var TheTopCatFormKey = document.forms["Form1"].topCatFormKey;

if (TheTopCatFormKey != null)
{

	topCat = new TopCategory('A', '农林牧渔')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '1', '农业')
	sCat = new Category(topCat, '2', '林业')
	sCat = new Category(topCat, '3', '畜牧业')
	sCat = new Category(topCat, '011', '植物花卉') 
		
	topCat = new TopCategory('B', '食品饮料')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '5', '煤炭开采和洗选')
	sCat = new Category(topCat, '6', '石油和天然气开采')
	sCat = new Category(topCat, '7', '黑色金属矿采选')
	sCat = new Category(topCat, '8', '有色金属矿采选')
	sCat = new Category(topCat, '9', '非金属矿采选')
	sCat = new Category(topCat, '10', '其他采矿')

	topCat = new TopCategory('C', '冶金矿产')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '11', '汽车制造')
	sCat = new Category(topCat, '12', '农副食品')
	sCat = new Category(topCat, '13', '食品饮料')
	sCat = new Category(topCat, '14', '烟草')
	sCat = new Category(topCat, '15', '纺织')
	sCat = new Category(topCat, '16', '服装鞋帽')
	sCat = new Category(topCat, '17', '皮革毛皮')
	sCat = new Category(topCat, '18', '木材加工')
	sCat = new Category(topCat, '19', '家具制造')
	sCat = new Category(topCat, '20', '造纸及纸制品')
	sCat = new Category(topCat, '201', '工程机械')      	 
	sCat = new Category(topCat, '202', '建筑用品')
	sCat = new Category(topCat, '203', '水泥')
	sCat = new Category(topCat, '204', '汽车零部件')
	sCat = new Category(topCat, '205', '汽车配件')
	sCat = new Category(topCat, '206', '医疗器械')
	sCat = new Category(topCat, '207', '包装业')
	sCat = new Category(topCat, '21', '印刷业')
	sCat = new Category(topCat, '22', '文教体育用品')
	sCat = new Category(topCat, '23', '石油加工')
	sCat = new Category(topCat, '24', '化学原料及制品')
	sCat = new Category(topCat, '25', '生物医药')
	sCat = new Category(topCat, '26', '化学纤维')
	sCat = new Category(topCat, '27', '橡胶塑料')
	sCat = new Category(topCat, '28', '金属制品')
	sCat = new Category(topCat, '29', '通用设备')
	sCat = new Category(topCat, '30', '专用设备')
	sCat = new Category(topCat, '31', '电气机械及器材')
	sCat = new Category(topCat, '32', '仪器仪表')
	sCat = new Category(topCat, '33', '工艺品')
	sCat = new Category(topCat, '34', '新材料')
	sCat = new Category(topCat, '36', '燃气')
	sCat = new Category(topCat, '37', '水力')
	sCat = new Category(topCat, '38', '新能源')
	
	topCat = new TopCategory('D', '机械制造')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '35', '电力、热力')

	topCat = new TopCategory('E', '汽车汽配')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '39', '房地产')
	sCat = new Category(topCat, '40', '建筑安装')
	sCat = new Category(topCat, '41', '建筑装饰')
	sCat = new Category(topCat, '42', '其他建筑')

	topCat = new TopCategory('F', '能源动力')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '43', '铁路运输')
	sCat = new Category(topCat, '431', '物流')
	sCat = new Category(topCat, '44', '道路运输')
	sCat = new Category(topCat, '45', '城市公共交通')
	sCat = new Category(topCat, '46', '水上运输')
	sCat = new Category(topCat, '47', '航空运输')
	sCat = new Category(topCat, '48', '管道运输')
	sCat = new Category(topCat, '49', '其他运输服务')
	
	topCat = new TopCategory('G', '石油化工')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '50', '仓储业')
	sCat = new Category(topCat, '51', '邮政业')
	
	topCat = new TopCategory('H', '纺织服装')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '52', '通信设备')
	sCat = new Category(topCat, '53', '计算机')
	sCat = new Category(topCat, '54', '软件业')
	sCat = new Category(topCat, '55', '电信和信息传输')
		
	
	topCat = new TopCategory('I', '环境保护')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '56', '批发业')
	sCat = new Category(topCat, '57', '零售业')
	
	topCat = new TopCategory('J', '医疗保健')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '58', '住宿业')
	sCat = new Category(topCat, '59', '餐饮业')
	sCat = new Category(topCat, '60', '娱乐业')
	
	
	topCat = new TopCategory('K', '生物科技')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '61', '银行业')
	sCat = new Category(topCat, '62', '证券业')
	sCat = new Category(topCat, '63', '保险业')
	sCat = new Category(topCat, '64', '其他金融活动')
	
	topCat = new TopCategory('L', '教育培训')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '65', '租赁业')
	sCat = new Category(topCat, '66', '商务服务业')
	
	
	topCat = new TopCategory('M', '印刷出版')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '67', '研究与试验发展')
	sCat = new Category(topCat, '671', '高新技术')
	sCat = new Category(topCat, '68', '专业技术服务')
	sCat = new Category(topCat, '69', '科技交流')
	sCat = new Category(topCat, '70', '推广服务')
	sCat = new Category(topCat, '71', '地质勘查')
	
	topCat = new TopCategory('N', '广告传媒')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '72', '水利管理')
	sCat = new Category(topCat, '73', '环境管理')
	sCat = new Category(topCat, '74', '公共设施管理')
	
	topCat = new TopCategory('P', '电子通讯')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '75', '卫生')
	sCat = new Category(topCat, '751', '教育学校')		
	sCat = new Category(topCat, '752', '保健品')
	sCat = new Category(topCat, '76', '社会保障业')
	sCat = new Category(topCat, '77', '社会福利业')
	
 	topCat = new TopCategory('Q', '建筑建材')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '78', '新闻出版业')
	sCat = new Category(topCat, '79', '广播、电视、电影和音像业')
	sCat = new Category(topCat, '80', '文化艺术业')
	sCat = new Category(topCat, '81', '体育')
		
  	topCat = new TopCategory('O', '影视娱乐')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '82', '旅游开发')
	
	topCat = new TopCategory('R', '信息产业')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '83', '信息产业')
	
	topCat = new TopCategory('S', '高新技术')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '84', '高新技术')
	
	topCat = new TopCategory('T', '基础设施')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '85', '基础设施')
	
	topCat = new TopCategory('U', '交通运输')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '86', '交通运输')


	topCat = new TopCategory('V', '物流仓储')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '87', '物流仓储')


	topCat = new TopCategory('W', '金融投资')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '88', '金融投资')


	topCat = new TopCategory('X', '旅游休闲')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '89', '旅游休闲')
	
	
	topCat = new TopCategory('Y', '社会服务')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '90', '社会服务')
	
	
	topCat = new TopCategory('Z', '酒店餐饮')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '91', '酒店餐饮')
		
	topCat = new TopCategory('#', '批发零售')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '92', '批发零售')
	
		
	topCat = new TopCategory('$', '房地产业')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '100', '房地产业')
	
		
	topCat = new TopCategory('*', '其他行业')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '101', '其他行业')

	initTopCategoryForm();
	var IndustryBID;
	var IndustryMID;
	IndustryBID =document.forms["Form1"].hideIndustryB.value;
	IndustryMID=document.forms["Form1"].hideIndustryM.value;
	selectIndustryBID(IndustryBID,IndustryMID)	
}	
