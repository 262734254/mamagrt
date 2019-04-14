//.��ڲ���
	var topCatForm = Form1.topCatFormKey;
	var secondCatForm = Form1.secondCatFormKey;
	
	var PtopCatForm = Form1.PtopCatFormKey;
	var PsecondCatForm = Form1.PsecondCatFormKey;	

	var EtopCatForm = Form1.EtopCatFormKey;
	var EsecondCatForm = Form1.EsecondCatFormKey;	
	
	var topCatArr = new Array();        
	var PtopCatArr= new Array();
	var EtopCatArr= new Array();
	
	
	//�����б����ʼ����
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
		//���б����Ϣȫ���������б�֮��			
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
	topCat = new TopCategory('R', 'Ͷ�ʼ�����Ŀ')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '83', 'ũҵ')
	sCat = new Category(topCat, '84', '����')
	sCat = new Category(topCat, '85', '����')
	sCat = new Category(topCat, '86', '��ȫ����')
	sCat = new Category(topCat, '87', 'ʳƷ����')
	sCat = new Category(topCat, '88', '���ӵ繤')
	sCat = new Category(topCat, '89', 'ӡˢ������')
	sCat = new Category(topCat, '90', '��֯Ƥ��')
	sCat = new Category(topCat, '91', '����')
	sCat = new Category(topCat, '92', '���')
	sCat = new Category(topCat, '93', '��Դ')      	 
	sCat = new Category(topCat, '94', '����ҵ')
	sCat = new Category(topCat, '95', 'ͨѶ')
	sCat = new Category(topCat, '96', '��ͨ����')
	sCat = new Category(topCat, '97', '��ҵ��Ʒ')
	sCat = new Category(topCat, '98', '��ҵ����')
	sCat = new Category(topCat, '99', '�Ҿ���Ʒ')
	sCat = new Category(topCat, '100', '����')
	sCat = new Category(topCat, '101', 'ӡˢ����')
	sCat = new Category(topCat, '102', '���õ���')
	sCat = new Category(topCat, '103', 'ҽҩ����')
	sCat = new Category(topCat, '104', '��Ħ�����')
	sCat = new Category(topCat, '105', '������е')
	sCat = new Category(topCat, '106', '����������')
	sCat = new Category(topCat, '107', '������')
	sCat = new Category(topCat, '108', '������Ʒ')
	sCat = new Category(topCat, '109', '�˶�����')
	sCat = new Category(topCat, '110', 'ұ����')
	sCat = new Category(topCat, '111', '�칫���Ľ�')
	sCat = new Category(topCat, '112', '���ز�')
	
	topCat = new TopCategory('R', '���ʼ�����Ŀ')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '83', 'ũҵ')
	sCat = new Category(topCat, '84', '����')
	sCat = new Category(topCat, '85', '����')
	sCat = new Category(topCat, '86', '��ȫ����')
	sCat = new Category(topCat, '87', 'ʳƷ����')
	sCat = new Category(topCat, '88', '���ӵ繤')
	sCat = new Category(topCat, '89', 'ӡˢ������')
	sCat = new Category(topCat, '90', '��֯Ƥ��')
	sCat = new Category(topCat, '91', '����')
	sCat = new Category(topCat, '92', '���')
	sCat = new Category(topCat, '93', '��Դ')      	 
	sCat = new Category(topCat, '94', '����ҵ')
	sCat = new Category(topCat, '95', 'ͨѶ')
	sCat = new Category(topCat, '96', '��ͨ����')
	sCat = new Category(topCat, '97', '��ҵ��Ʒ')
	sCat = new Category(topCat, '98', '��ҵ����')
	sCat = new Category(topCat, '99', '�Ҿ���Ʒ')
	sCat = new Category(topCat, '100', '����')
	sCat = new Category(topCat, '101', 'ӡˢ����')
	sCat = new Category(topCat, '102', '���õ���')
	sCat = new Category(topCat, '103', 'ҽҩ����')
	sCat = new Category(topCat, '104', '��Ħ�����')
	sCat = new Category(topCat, '105', '������е')
	sCat = new Category(topCat, '106', '����������')
	sCat = new Category(topCat, '107', '������')
	sCat = new Category(topCat, '108', '������Ʒ')
	sCat = new Category(topCat, '109', '�˶�����')
	sCat = new Category(topCat, '110', 'ұ����')
	sCat = new Category(topCat, '111', '�칫���Ľ�')
	sCat = new Category(topCat, '112', '���ز�')

	initTopCategoryForm();
	var IndustryBID;
	var IndustryMID;
	IndustryBID =document.Form1.hideIndustryB.value;
	IndustryMID=document.Form1.hideIndustryM.value;
	selectIndustryBID(IndustryBID,IndustryMID)	
}	
