//.��ڲ���
	var topCatForm = document.forms["Form1"].topCatFormKey;
	var secondCatForm = document.forms["Form1"].secondCatFormKey;
	
	var PtopCatForm = document.forms["Form1"].PtopCatFormKey;
	var PsecondCatForm = document.forms["Form1"].PsecondCatFormKey;	

	var EtopCatForm = document.forms["Form1"].EtopCatFormKey;
	var EsecondCatForm = document.forms["Form1"].EsecondCatFormKey;	
	
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
		//���б����Ϣȫ���������б�֮��			
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

	topCat = new TopCategory('A', 'ũ������')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '1', 'ũҵ')
	sCat = new Category(topCat, '2', '��ҵ')
	sCat = new Category(topCat, '3', '����ҵ')
	sCat = new Category(topCat, '011', 'ֲ�ﻨ��') 
		
	topCat = new TopCategory('B', 'ʳƷ����')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '5', 'ú̿���ɺ�ϴѡ')
	sCat = new Category(topCat, '6', 'ʯ�ͺ���Ȼ������')
	sCat = new Category(topCat, '7', '��ɫ�������ѡ')
	sCat = new Category(topCat, '8', '��ɫ�������ѡ')
	sCat = new Category(topCat, '9', '�ǽ������ѡ')
	sCat = new Category(topCat, '10', '�����ɿ�')

	topCat = new TopCategory('C', 'ұ����')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '11', '��������')
	sCat = new Category(topCat, '12', 'ũ��ʳƷ')
	sCat = new Category(topCat, '13', 'ʳƷ����')
	sCat = new Category(topCat, '14', '�̲�')
	sCat = new Category(topCat, '15', '��֯')
	sCat = new Category(topCat, '16', '��װЬñ')
	sCat = new Category(topCat, '17', 'Ƥ��ëƤ')
	sCat = new Category(topCat, '18', 'ľ�ļӹ�')
	sCat = new Category(topCat, '19', '�Ҿ�����')
	sCat = new Category(topCat, '20', '��ֽ��ֽ��Ʒ')
	sCat = new Category(topCat, '201', '���̻�е')      	 
	sCat = new Category(topCat, '202', '������Ʒ')
	sCat = new Category(topCat, '203', 'ˮ��')
	sCat = new Category(topCat, '204', '�����㲿��')
	sCat = new Category(topCat, '205', '�������')
	sCat = new Category(topCat, '206', 'ҽ����е')
	sCat = new Category(topCat, '207', '��װҵ')
	sCat = new Category(topCat, '21', 'ӡˢҵ')
	sCat = new Category(topCat, '22', '�Ľ�������Ʒ')
	sCat = new Category(topCat, '23', 'ʯ�ͼӹ�')
	sCat = new Category(topCat, '24', '��ѧԭ�ϼ���Ʒ')
	sCat = new Category(topCat, '25', '����ҽҩ')
	sCat = new Category(topCat, '26', '��ѧ��ά')
	sCat = new Category(topCat, '27', '������')
	sCat = new Category(topCat, '28', '������Ʒ')
	sCat = new Category(topCat, '29', 'ͨ���豸')
	sCat = new Category(topCat, '30', 'ר���豸')
	sCat = new Category(topCat, '31', '������е������')
	sCat = new Category(topCat, '32', '�����Ǳ�')
	sCat = new Category(topCat, '33', '����Ʒ')
	sCat = new Category(topCat, '34', '�²���')
	sCat = new Category(topCat, '36', 'ȼ��')
	sCat = new Category(topCat, '37', 'ˮ��')
	sCat = new Category(topCat, '38', '����Դ')
	
	topCat = new TopCategory('D', '��е����')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '35', '����������')

	topCat = new TopCategory('E', '��������')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '39', '���ز�')
	sCat = new Category(topCat, '40', '������װ')
	sCat = new Category(topCat, '41', '����װ��')
	sCat = new Category(topCat, '42', '��������')

	topCat = new TopCategory('F', '��Դ����')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '43', '��·����')
	sCat = new Category(topCat, '431', '����')
	sCat = new Category(topCat, '44', '��·����')
	sCat = new Category(topCat, '45', '���й�����ͨ')
	sCat = new Category(topCat, '46', 'ˮ������')
	sCat = new Category(topCat, '47', '��������')
	sCat = new Category(topCat, '48', '�ܵ�����')
	sCat = new Category(topCat, '49', '�����������')
	
	topCat = new TopCategory('G', 'ʯ�ͻ���')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '50', '�ִ�ҵ')
	sCat = new Category(topCat, '51', '����ҵ')
	
	topCat = new TopCategory('H', '��֯��װ')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '52', 'ͨ���豸')
	sCat = new Category(topCat, '53', '�����')
	sCat = new Category(topCat, '54', '���ҵ')
	sCat = new Category(topCat, '55', '���ź���Ϣ����')
		
	
	topCat = new TopCategory('I', '��������')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '56', '����ҵ')
	sCat = new Category(topCat, '57', '����ҵ')
	
	topCat = new TopCategory('J', 'ҽ�Ʊ���')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '58', 'ס��ҵ')
	sCat = new Category(topCat, '59', '����ҵ')
	sCat = new Category(topCat, '60', '����ҵ')
	
	
	topCat = new TopCategory('K', '����Ƽ�')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '61', '����ҵ')
	sCat = new Category(topCat, '62', '֤ȯҵ')
	sCat = new Category(topCat, '63', '����ҵ')
	sCat = new Category(topCat, '64', '�������ڻ')
	
	topCat = new TopCategory('L', '������ѵ')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '65', '����ҵ')
	sCat = new Category(topCat, '66', '�������ҵ')
	
	
	topCat = new TopCategory('M', 'ӡˢ����')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '67', '�о������鷢չ')
	sCat = new Category(topCat, '671', '���¼���')
	sCat = new Category(topCat, '68', 'רҵ��������')
	sCat = new Category(topCat, '69', '�Ƽ�����')
	sCat = new Category(topCat, '70', '�ƹ����')
	sCat = new Category(topCat, '71', '���ʿ���')
	
	topCat = new TopCategory('N', '��洫ý')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '72', 'ˮ������')
	sCat = new Category(topCat, '73', '��������')
	sCat = new Category(topCat, '74', '������ʩ����')
	
	topCat = new TopCategory('P', '����ͨѶ')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '75', '����')
	sCat = new Category(topCat, '751', '����ѧУ')		
	sCat = new Category(topCat, '752', '����Ʒ')
	sCat = new Category(topCat, '76', '��ᱣ��ҵ')
	sCat = new Category(topCat, '77', '��ḣ��ҵ')
	
 	topCat = new TopCategory('Q', '��������')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '78', '���ų���ҵ')
	sCat = new Category(topCat, '79', '�㲥�����ӡ���Ӱ������ҵ')
	sCat = new Category(topCat, '80', '�Ļ�����ҵ')
	sCat = new Category(topCat, '81', '����')
		
  	topCat = new TopCategory('O', 'Ӱ������')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '82', '���ο���')
	
	topCat = new TopCategory('R', '��Ϣ��ҵ')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '83', '��Ϣ��ҵ')
	
	topCat = new TopCategory('S', '���¼���')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '84', '���¼���')
	
	topCat = new TopCategory('T', '������ʩ')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '85', '������ʩ')
	
	topCat = new TopCategory('U', '��ͨ����')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '86', '��ͨ����')


	topCat = new TopCategory('V', '�����ִ�')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '87', '�����ִ�')


	topCat = new TopCategory('W', '����Ͷ��')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '88', '����Ͷ��')


	topCat = new TopCategory('X', '��������')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '89', '��������')
	
	
	topCat = new TopCategory('Y', '������')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '90', '������')
	
	
	topCat = new TopCategory('Z', '�Ƶ����')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '91', '�Ƶ����')
		
	topCat = new TopCategory('#', '��������')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '92', '��������')
	
		
	topCat = new TopCategory('$', '���ز�ҵ')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '100', '���ز�ҵ')
	
		
	topCat = new TopCategory('*', '������ҵ')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat, '101', '������ҵ')

	initTopCategoryForm();
	var IndustryBID;
	var IndustryMID;
	IndustryBID =document.forms["Form1"].hideIndustryB.value;
	IndustryMID=document.forms["Form1"].hideIndustryM.value;
	selectIndustryBID(IndustryBID,IndustryMID)	
}	
