
//.��ڲ���

	var topCatForm = Form1.listBig;
	var secondCatForm = Form1.listSmall;
	
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
		//���б����Ϣȫ���������б�֮��			
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
	topCat = new TopCategory('100', '��վ��������')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat,'101','��վ����')
	sCat = new Category(topCat,'102','���ܷ���')
	sCat = new Category(topCat,'103','�ٶȻ���')
	sCat = new Category(topCat,'104','����̬��')
	sCat = new Category(topCat,'105','������ѯ')
	sCat = new Category(topCat,'106','����')


	
		
	topCat = new TopCategory('200','��վ��Ŀ����')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat,'201','��վ��ҳ')
	sCat = new Category(topCat,'202','��Ա����ϵͳ')
	sCat = new Category(topCat,'203','��������')
	sCat = new Category(topCat,'204','Ͷ��Ƶ��')
	sCat = new Category(topCat,'205','����Ƶ��')
	sCat = new Category(topCat,'206','��ҵƵ��')
	sCat = new Category(topCat,'207','�̻�Ƶ��')
	sCat = new Category(topCat,'208','��ѶƵ��')
	sCat = new Category(topCat,'209','��վƵ��')
	sCat = new Category(topCat,'210','�������ֲ�')
	sCat = new Category(topCat,'211','�ɹ�����')
	sCat = new Category(topCat,'212','��Ӣ����')
	sCat = new Category(topCat,'213','ר����ѯ')
	sCat = new Category(topCat,'214','��չר��')
	sCat = new Category(topCat,'215','��Ȩ����')
	sCat = new Category(topCat,'216','�б�Ͷ��')
	sCat = new Category(topCat,'217','��ɫ����')
	sCat = new Category(topCat,'218','���˺���')
	sCat = new Category(topCat,'219','������Ƭ')
	sCat = new Category(topCat,'220','������̳')
	sCat = new Category(topCat,'221','�������ͨ')

	topCat = new TopCategory('300','��վ���ܽ���')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat,'301','��Աע��')
	sCat = new Category(topCat,'302','��Ա��¼')
	sCat = new Category(topCat,'303','��վ����')
	sCat = new Category(topCat,'304','������ֵ')
	sCat = new Category(topCat,'305','��������')
	sCat = new Category(topCat,'306','��Ϣ����')
	sCat = new Category(topCat,'307','��Ϣ����')
	sCat = new Category(topCat,'308','��Ϣ�ղ�')
	sCat = new Category(topCat,'309','��������')
	sCat = new Category(topCat,'310','ҳ�涩��')
	sCat = new Category(topCat,'311','��������')
	sCat = new Category(topCat,'312','վ�ڶ���')
	sCat = new Category(topCat,'313','�����޸�')
	sCat = new Category(topCat,'314','�����һ�')
	sCat = new Category(topCat,'315','��Ƭ����')
	sCat = new Category(topCat,'316','�ʻ���Ϣ')
	sCat = new Category(topCat,'317','���������')
	
	
	topCat = new TopCategory('400','��վ������')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat,'401','��վҳ��')
	sCat = new Category(topCat,'402','��վ����')
	sCat = new Category(topCat,'403','��վҵ��')
	sCat = new Category(topCat,'404','��վ��ѵ')
	sCat = new Category(topCat,'405','��վ����')
	
	topCat = new TopCategory('500','�����ϢͶ��')

	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat,'501','������Ϣ')
	sCat = new Category(topCat,'502','Ͷ����Ϣ')
	sCat = new Category(topCat,'503','������Ϣ')
	sCat = new Category(topCat,'504','��ҵ��Ϣ')
	sCat = new Category(topCat,'505','�̻���Ϣ')
	sCat = new Category(topCat,'506','������Ϣ')

	topCat = new TopCategory('600','����ҵ����ѯ���걨')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat,'601','������')
	sCat = new Category(topCat,'602','�����')
	sCat = new Category(topCat,'603','���󷢲�')
	sCat = new Category(topCat,'604','������')
	sCat = new Category(topCat,'605','������Ƭ')
	sCat = new Category(topCat,'606','�Կ��н�')
	sCat = new Category(topCat,'607','��վ����')
	sCat = new Category(topCat,'608','��ɫ�����걨')
	sCat = new Category(topCat,'609','����')
	
	topCat = new TopCategory('700','רҵ������ѯ')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat,'701','����ġ�ʽ����ί��')
	sCat = new Category(topCat,'702','����ġ�ʽ����ί��')
	sCat = new Category(topCat,'703','��ҵ�滮���ҵ����')
	sCat = new Category(topCat,'704','����פ�����̴���')
	sCat = new Category(topCat,'705','����Ͷ�ʻ�������')
	sCat = new Category(topCat,'706','����ý������')
	sCat = new Category(topCat,'707','������ѯ')
	sCat = new Category(topCat,'708','Ͷ����ѯ')
	sCat = new Category(topCat,'709','����')
	
	topCat = new TopCategory('800','��������')
	topCatArr = topCatArr.concat(topCat)
	sCat = new Category(topCat,'801','����')
		
	

	initTopCategoryForm();
	var BigID;
	var SmallID;
	BigID =document.Form1.hideBig.value;
	SmallID=document.Form1.hideBig.value;
	selectBigID(BigID,SmallID)	
}	
