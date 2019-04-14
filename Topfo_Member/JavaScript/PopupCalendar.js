// ********************
// Begin Popup Calendar
// ********************
var popCalDstFld;
var temp;
var popCalWin;
var divCal;
var iframeTemp;
var currentDate;
var imgPath = "";

var divCalHeight = 180;
var divCalWidth = 255;

// ******************************
// Expected params:
// [0] Window Name
// [1] Destination Field
// [2] Short Date Format
// [3] Month Names
// [4] Day Names
// [5] Localized Today string
// [6] Localized Close string
// [7] Window Title
// [8] First Day of Week
// ******************************
function popupCal()
{
	//debugger;			//remove slashes to activate debugging in Visual Studio
	var tmpDate         = new Date();
	var tmpString       = "";
	var tmpNum          = 0;
	var popCalDateVal;
	//var dstWindowName   = "";

	//Initialize the window to an empty object.
	popCalWin = new Object();
	
	//Check for the right number of arguments
	if (arguments.length < 2)
	{
		alert("popupCal(): Wrong number of arguments.");
		return void(0);
	}
	//Get the command line arguments -- Localization is optional
	imgPath = popupCal.arguments[0];
	//dstWindowName = popupCal.arguments[0];
	popCalDstFld = popupCal.arguments[1];
	temp = popupCal.arguments[1];
	popCalDstFmt = popupCal.arguments[2]; //Localized Short Date Format String
	popCalMonths = popupCal.arguments[3]; //Localized Month Names String
	popCalDays = popupCal.arguments[4];   //Localized Day Names String
	popCalToday = popupCal.arguments[5];  //Localized Today string
	popCalClose = popupCal.arguments[6];  //Localized Close string
	popCalTitle = popupCal.arguments[7];  //Window Title
	popCalFirstDayWeek = popupCal.arguments[8];  //First Day of Week
	popCalFirstDayWeek = 0;
	//check destination field name
	if (popCalDstFld != "")
	  popCalDstFld = document.getElementById(popCalDstFld);

	//default localized short date format if not provided
	if (popCalDstFmt == "")
	  popCalDstFmt = "yyyy-mm-dd";

	//default localized months string if not provided
	if (popCalMonths == "")
	  popCalMonths = "January,February,March,April,May,June,July,August,September,October,November,December";
 
	//default localized months string if not provided
	if (popCalDays == "")
	 {
	     popCalDays = "Sun,Mon,Tue,Wed,Thu,Fri,Sat";
	 }
	 else
	  {
	  	     popCalDays = "日,一,二,三,四,五,六";

	  }
	
	//default localized today string if not provided
	if (popCalToday == "" || typeof popCalToday == "undefined")
	  popCalToday = "Today";

	//default localized close string if not provided
	if (popCalClose == "" || typeof popCalClose == "undefined")
	  popCalClose = "Close";

	//default window title if not provided
	if (popCalTitle == "" || typeof popCalTitle == "undefined")
	  popCalTitle = "Calendar";
 
	tmpString = new String(popCalDstFld.value);  
	//If tmpString is empty (meaning that the field is empty) 
	//use todays date as the starting point
	if(tmpString == "")
		popCalDateVal = new Date()
	else
	{
		//Make sure the century is included, if it isn't, add this 
		//century to the value that was in the field
		tmpNum = tmpString.lastIndexOf( "/" );
		if ( (tmpString.length - tmpNum) == 3 )
		{
			tmpString = tmpString.substring(0,tmpNum + 1)+"20"+tmpString.substr(tmpNum+1);
			popCalDateVal = new Date(tmpString);
		}
		else
		{
			//localized date support:
			//If we got to this point, it means the field that was passed 
			//in has no slashes in it. Use an extra function to build the date 
			//according to supplied date formatstring.
			popCalDateVal = getDateFromFormat(tmpString,popCalDstFmt);
		}
	}
	
	//Make sure the date is a valid date.  Set it to today if it is invalid
	//"NaN" is the return value for an invalid date
	if( popCalDateVal.toString() == "NaN" || popCalDateVal.toString() == "0")
	{
		popCalDateVal = new Date();
		popCalDstFld.value = "";
	}
	
	currentDate = popCalDateVal;
			
	//Set the base date to midnight of the first day of the specified month, 
	//this makes things easier?
 	var dateString = String(popCalDateVal.getMonth()+1) + "/" + String(popCalDateVal.getDate()) + "/" + String(popCalDateVal.getFullYear());

	//Call the routine to draw the initial calendar
	reloadCalPopup(dateString);
	
	return void(0);
}
 
function closeCalPopup()
{
	//Can't tell the child window to close itself, the parent window has to 
	//tell it to close.
	//popCalWin.close();
	divCal.style.display = "none";
	iframeTemp.style.display = "none";
	return void(0);
}
 
function reloadCalPopup() //[0]dateString, [1]dstWindowName
{
	var tmpDate = new Date( reloadCalPopup.arguments[0] );
	//alert(tmpDate);
	
	if (tmpDate.toString() == "Invalid Date")
	    tmpDate = new Date();

	tmpDate.setDate(1);
	
	//Get the calendar data
	var popCalData = calPopupSetData(tmpDate);
	//document.write(popCalData);

 if(divCal == null || typeof(divCal) == "undefined")
 {

	divCal = document.createElement("DIV");
	divCal.id = "divCalendar";
	divCal.style.display = "none";
	divCal.style.height = divCalHeight;
	divCal.style.width = divCalWidth;
	divCal.style.position = "absolute";
	divCal.style.background = "#F1F1F1";
	divCal.style.zIndex = 150;
	divCal.style.border = "1px solid #404040";
	document.body.appendChild(divCal);
}
 if(iframeTemp == null || typeof(iframeTemp) == "undefined")
 {	
	iframeTemp = document.createElement('IFRAME');
	iframeTemp.src = '';	//TODO:  FIX FOR SSL!!!
	iframeTemp.height = divCalHeight;
	iframeTemp.width = divCalWidth;
		iframeTemp.style.position = "absolute";
	iframeTemp.style.background = "#F1F1F1";
	//iframeTemp.style.visibility = 'hidden';
	  iframeTemp.style.display = "none";
		iframeTemp.style.zIndex = 149;
	document.body.appendChild(iframeTemp);	
 }
	//this is the line with the big problem
  //popCalWin.document.write(popCalData);
  divCal.innerHTML = popCalData;
  //alert(popCalDstFld.id + "," + popCalDstFld.offsetWidth + ", " + popCalDstFld.offsetHeight + " , " + popCalDstFld.style.left +" , " + popCalDstFld.style.top);
  //divCal.style.posleft = popCalDstFld.style.posLeft ;
  //divCal.style.posTop = popCalDstFld.style.posTop ;
  //popCalDstFld.style.posTop = 500;
  var Location = GetAbsoluteLocationEx(popCalDstFld);
  var divLeft = Location.absoluteLeft;
  var divTop = Location.absoluteTop + Location.offsetHeight + 1;
  if(divLeft + divCalWidth > window.screen.width)
  {
	  divLeft = window.screen.width - divCalWidth;
	}
	//if(divTop + divCalHeight > window.screen.height)
	//{
	//	divTop = window.screen.height - divCalHeight;
	//}
	
   iframeTemp.style.left = divCal.style.left = divLeft;
  iframeTemp.style.top = divCal.style.top = divTop;
  // iframeTemp.style.left = divCal.style.left = window.screen.width / 2 - divCalWidth;
  // iframeTemp.style.top = divCal.style.top = window.screen.height / 2 ;

  divCal.style.display = "block";
  iframeTemp.style.display = "block";
  //iframeTemp.style.visibility = "visible";

	return void(1);
}
 
function calPopupSetData(firstDay)
{
	
	//var firstDay = new Date(currentDate);
	//firstDay.setDate(1);


	var popCalData = "";
    var lastDate = 0;
	var fnt = new Array( "<FONT SIZE=\"1\">", "<FONT SIZE=\"2\">", "<FONT SIZE=\"2\" COLOR=\"#EF741D\">","<FONT SIZE=\"2\" COLOR=\"blue\">");
	var dtToday = new Date();
	var thisMonth = firstDay.getMonth();
	var thisYear = firstDay.getFullYear();
	var nPrevMonth = (thisMonth == 0 ) ? 11 : (thisMonth - 1);
	var nNextMonth = (thisMonth == 11 ) ? 0 : (thisMonth + 1);
	var nPrevMonthYear = (nPrevMonth == 11) ? (thisYear - 1): thisYear;
	var nNextMonthYear = (nNextMonth == 0) ? (thisYear + 1): thisYear;
	var sToday = String((dtToday.getMonth()+1) + "/01/" + dtToday.getFullYear());
	var sPrevMonth = String((nPrevMonth+1) + "/01/" + nPrevMonthYear);
	var sNextMonth = String((nNextMonth+1) + "/01/" + nNextMonthYear);
	var sPrevYear1 = String((thisMonth+1) + "/01/" + (thisYear - 1));
	var sNextYear1 = String((thisMonth+1) + "/01/" + (thisYear + 1));
 	var tmpDate = new Date( sNextMonth );
	
	tmpDate = new Date( tmpDate.valueOf() - 1001 );
	lastDate = tmpDate.getDate();

	if (this.popCalMonths.split) // javascript 1.1 defensive code
	{
		var monthNames = this.popCalMonths.split(",");
		var dayNames = this.popCalDays.split(",");
	}
	else  // Need to build a js 1.0 split algorithm, default English for now
	{
		var monthNames = new Array("January","February","March","April","May","June","July","August","September","October","November","December");
		var dayNames = new Array("Sun","Mon","Tue","Wed","Thu","Fri","Sat")
	}

 	var styles = "<style><!-- .divCalendar{font-family:Arial,Helvetica,sans-serif;font-size:9pt}; divCalendar.td {  font-family: Arial, Helvetica, sans-serif; font-size: 9pt; color: #666666}; divCalendar.A { text-decoration: none; };TD.day { border-bottom: solid black; border-width: 0px; }--></style>"
	var cellAttribs = " class=\"day\" BGCOLOR=\"#F1F1F1\"onMouseOver=\"temp=this.style.backgroundColor;this.style.backgroundColor='#CCCCCC';\" onMouseOut=\"this.style.backgroundColor=temp;\""
	var cellAttribs2 = " BGCOLOR=\"#F1F1F1\" onMouseOver=\"temp=this.style.backgroundColor;this.style.backgroundColor='#CCCCCC';\" onMouseOut=\"this.style.backgroundColor=temp;\""
	var htmlHead = "" //"<HTML><HEAD><TITLE>"+popCalTitle+"</TITLE>" + styles + "</HEAD><BODY BGCOLOR=\"#F1F1F1\" TEXT=\"#000000\" LINK=\"#364180\" ALINK=\"#FF8100\" VLINK=\"#424282\">";
	var htmlTail = "" //"</BODY></HTML>";
	var closeAnchor = "" // "<CENTER><input type=button value=\""+popCalClose+"\" onClick=\"javascript:closeCalPopup()\"></CENTER>";            
	var todayAnchor = "<A HREF=\"javascript:reloadCalPopup('"+sToday+"');\">"+popCalToday+"</A>";
	var prevMonthAnchor = "<A HREF=\"javascript:reloadCalPopup('"+sPrevMonth+"');\"><strong>" + monthNames[nPrevMonth] + "</strong></A>";
	var nextMonthAnchor = "<A HREF=\"javascript:reloadCalPopup('"+sNextMonth+"');\"><strong>" + monthNames[nNextMonth] + "</strong></A>";
	var prevYear1Anchor = "<A HREF=\"javascript:reloadCalPopup('"+sPrevYear1+"');\"><strong>"+(thisYear-1)+"</strong></A>";
	var nextYear1Anchor = "<A HREF=\"javascript:reloadCalPopup('"+sNextYear1+"');\"><strong>"+(thisYear+1)+"</strong></A>";
		
	popCalData += (htmlHead + fnt[1]);
	popCalData += ("<DIV align=\"center\">");
	popCalData += ("<TABLE BORDER=\"0\" cellspacing=\"0\" callpadding=\"0\" width=\"250\"><TR><TD width=\"45\">&nbsp;</TD>\n");
	popCalData += ("<TD width=\"45\" align=\"center\" " + cellAttribs2);
	popCalData += (" >");
	popCalData += (fnt[0]+prevYear1Anchor+"</FONT></TD>");
	popCalData += ("<TD width=\"70\" align=\"center\" "+cellAttribs2);
	popCalData += (" >");
	popCalData += (fnt[0]+todayAnchor+"</FONT></TD>");
	popCalData += ("<TD width=\"45\" align=\"center\" "+cellAttribs2);
	popCalData += (" >");
	popCalData += (fnt[0]+nextYear1Anchor+"</FONT></TD><TD width=\"45\" align=\"right\"><input type=\"image\"  onClick=\"javascript:closeCalPopup()\" src=\"" + imgPath + "calx.gif\"></TD>");
	popCalData += ("</TR></TABLE>\n");
	popCalData += ("<TABLE BORDER=\"0\" cellspacing=\"0\" callpadding=\"0\" width=\"250\">\n");          
	popCalData += ("<TR><TD width=\"55\" align=\"center\" "+cellAttribs2);
	popCalData += (" >");
	popCalData += (fnt[0] + prevMonthAnchor + "</FONT></TD>");
	popCalData += ("<TD width=\"140\" align=\"center\">");
	popCalData += ("&nbsp;&nbsp;"+fnt[1]+"<FONT COLOR=\"#000000\"><strong>" + monthNames[thisMonth] + ", " + thisYear + "</strong>&nbsp;&nbsp;</FONT></TD>");
	popCalData += ("<TD width=\"55\" align=\"center\" "+cellAttribs2);
	popCalData += (" >");
	popCalData += (fnt[0]+nextMonthAnchor+"</FONT></TD></TR></TABLE>");       
	popCalData += ("<TABLE BORDER=\"0\" cellspacing=\"2\" cellpadding=\"1\"  width=\"245\">" );
	popCalData += ("");
	popCalData += ("<TR>\n");
	
	/*
	popCalData += ("<TD width=\"35\" align=\"center\">"+fnt[1]+"<FONT COLOR=\"#000000\">"+dayNames[0]+"</FONT></TD>");
	popCalData += ("<TD width=\"35\" align=\"center\">"+fnt[1]+"<FONT COLOR=\"#000000\">"+dayNames[1]+"</FONT></TD>");
	popCalData += ("<TD width=\"35\" align=\"center\">"+fnt[1]+"<FONT COLOR=\"#000000\">"+dayNames[2]+"</FONT></TD>");
	popCalData += ("<TD width=\"35\" align=\"center\">"+fnt[1]+"<FONT COLOR=\"#000000\">"+dayNames[3]+"</FONT></TD>");
	popCalData += ("<TD width=\"35\" align=\"center\">"+fnt[1]+"<FONT COLOR=\"#000000\">"+dayNames[4]+"</FONT></TD>");
	popCalData += ("<TD width=\"35\" align=\"center\">"+fnt[1]+"<FONT COLOR=\"#000000\">"+dayNames[5]+"</FONT></TD>");
	popCalData += ("<TD width=\"35\" align=\"center\">"+fnt[1]+"<FONT COLOR=\"#000000\">"+dayNames[6]+"</FONT></TD>");
	*/
	var xday = 0;


	for (xday = 0; xday < 7; xday++)
	{
		popCalData += ("<TD width=\"35\" height=\"35\" align=\"center\" valign=\"middle\">"+fnt[1]+"<FONT COLOR=\"black\"><strong>"+dayNames[(xday+popCalFirstDayWeek)%7]+"</strong></FONT></TD>");
	};
	popCalData += ("</TR>\n");
	
	var calDay = 0;
	var monthDate = 1;
	var weekDay = firstDay.getDay();
	do
	{
			//alert(popCalFirstDayWeek);
			//alert(popCalData);
			//alert(lastDate);
		popCalData += ("<TR>");
		for (calDay = 0; calDay < 7; calDay++ )
		{
			if(((weekDay+7-popCalFirstDayWeek)%7 != calDay) || (monthDate > lastDate))
			{
				popCalData += ("<TD width=\"35\">"+fnt[1]+"&nbsp;</FONT></TD>");
				continue;
			}
			else
			{
				anchorVal = "<A HREF=\"javascript:calPopupSetDate(popCalDstFld,'" + thisYear + "-" + (thisMonth+1) + "-"  + monthDate + "');closeCalPopup()\">";
				jsVal = "javascript:calPopupSetDate(popCalDstFld,'" + constructDate(monthDate,thisMonth+1,thisYear) + "');closeCalPopup()";

				popCalData += ("<TD width=\"35\" align=\"center\" " + cellAttribs + " onClick=\""+jsVal+"\">");
				
				//if ((firstDay.getMonth() == dtToday.getMonth()) && (monthDate == dtToday.getDate()) && (thisYear == dtToday.getFullYear()) )
				//	popCalData += (anchorVal+fnt[2]+monthDate+"</FONT></A></TD>\n");
				//else
				//	popCalData += (anchorVal+fnt[1]+monthDate+"</FONT></A></TD>\n");
				
					if ((firstDay.getMonth() == dtToday.getMonth()) && (monthDate == dtToday.getDate()) && (thisYear == dtToday.getFullYear()) )
					
					{
						popCalData += (anchorVal+fnt[2]+monthDate+"</FONT></A></TD>\n");
					}
				else
					{
						if (currentDate != null && (firstDay.getMonth() == currentDate.getMonth()) && (monthDate == currentDate.getDate()) && (thisYear == currentDate.getFullYear()) )
					
							{
									//alert(tmpDate.getDate());
								popCalData += (anchorVal+fnt[3]+monthDate+"</FONT></A></TD>\n");
							}
							else
							{
								popCalData += (anchorVal+fnt[1]+monthDate+"</FONT></A></TD>\n");
							}
					}
				
				weekDay++;
				monthDate++;
				//alert(monthDate);
			}
		}
		weekDay = popCalFirstDayWeek;
		popCalData += ("</TR>\n");
	} while( monthDate <= lastDate );
	
	popCalData += ("</TABLE></DIV>\n");
 
	//popCalData += (closeAnchor+"</FONT>"+htmlTail);
	return( popCalData );
}
 
function calPopupSetDate()
{
	calPopupSetDate.arguments[0].value = calPopupSetDate.arguments[1];
}

// utility function
function padZero(num)
{
  return ((num <= 9) ? ("0" + num) : num);
}

// Format short date
function constructDate(d,m,y)
{
  var fmtDate = this.popCalDstFmt
  fmtDate = fmtDate.replace ('dd', padZero(d))
  fmtDate = fmtDate.replace ('d', d)
  fmtDate = fmtDate.replace ('MM', padZero(m))
  fmtDate = fmtDate.replace ('M', m)
  fmtDate = fmtDate.replace ('yyyy', y)
  fmtDate = fmtDate.replace ('yy', padZero(y%100))
  return fmtDate;
}

// ------------------------------------------------------------------
// Utility functions for parsing in getDateFromFormat()
// ------------------------------------------------------------------
function _isInteger(val) {
	var digits="1234567890";
	for (var i=0; i < val.length; i++) {
		if (digits.indexOf(val.charAt(i))==-1) { return false; }
		}
	return true;
	}
function _getInt(str,i,minlength,maxlength) {
	for (var x=maxlength; x>=minlength; x--) {
		var token=str.substring(i,i+x);
		if (token.length < minlength) { return null; }
		if (_isInteger(token)) { return token; }
		}
	return null;
	}
	
// ------------------------------------------------------------------
// getDateFromFormat( date_string , format_string )
//
// This function takes a date string and a format string. It matches
// If the date string matches the format string, it returns the 
// getTime() of the date. If it does not match, it returns 0.
// ------------------------------------------------------------------
function getDateFromFormat(val,format) {
	val=val+"";
	format=format+"";
	var i_val=0;
	var i_format=0;
	var c="";
	var token="";
	var x,y;
	var now=new Date();
	var year=now.getYear();
	var month=now.getMonth()+1;
	var date=1;
		
	while (i_format < format.length) {
		// Get next token from format string
		c=format.charAt(i_format);
		token="";
		while ((format.charAt(i_format)==c) && (i_format < format.length)) {
			token += format.charAt(i_format++);
			}
		// Extract contents of value based on format token
		if (token=="yyyy" || token=="yy" || token=="y") {
			if (token=="yyyy") { x=4;y=4; }
			if (token=="yy")   { x=2;y=2; }
			if (token=="y")    { x=2;y=4; }
			year=_getInt(val,i_val,x,y);
			if (year==null) { return 0; }
			i_val += year.length;
			if (year.length==2) {
				if (year > 70) { year=1900+(year-0); }
				else { year=2000+(year-0); }
				}
			}
		else if (token=="MM"||token=="M") {
			month=_getInt(val,i_val,token.length,2);
			if(month==null||(month<1)||(month>12)){return 0;}
			i_val+=month.length;}
		else if (token=="dd"||token=="d") {
			date=_getInt(val,i_val,token.length,2);
			if(date==null||(date<1)||(date>31)){return 0;}
			i_val+=date.length;}
		else {
			if (val.substring(i_val,i_val+token.length)!=token) {return 0;}
			else {i_val+=token.length;}
			}
		}
	// If there are any trailing characters left in the value, it doesn't match
	if (i_val != val.length) { return 0; }
	// Is date valid for month?
	if (month==2) {
		// Check for leap year
		if ( ( (year%4==0)&&(year%100 != 0) ) || (year%400==0) ) { // leap year
			if (date > 29){ return 0; }
			}
		else { if (date > 28) { return 0; } }
		}
	if ((month==4)||(month==6)||(month==9)||(month==11)) {
		if (date > 30) { return 0; }
		}
	var newdate=new Date(year,month-1,date);
	return newdate;
	}
	
	function GetAbsoluteLocationEx(element) 
{ 
    if ( arguments.length != 1 || element == null ) 
    { 
        return null; 
    } 
    var elmt = element; 
    var offsetTop = elmt.offsetTop; 
    var offsetLeft = elmt.offsetLeft; 
    var offsetWidth = elmt.offsetWidth; 
    var offsetHeight = elmt.offsetHeight; 
    while( elmt = elmt.offsetParent ) 
    { 
          // add this judge 
        if ( elmt.style.position == 'absolute' || elmt.style.position == 'relative'  
            || ( elmt.style.overflow != 'visible' && elmt.style.overflow != '' ) ) 
        { 
            break; 
        }  
        offsetTop += elmt.offsetTop; 
        offsetLeft += elmt.offsetLeft; 
    } 
    return { absoluteTop: offsetTop, absoluteLeft: offsetLeft, 
        offsetWidth: offsetWidth, offsetHeight: offsetHeight }; 
} 

// ******************
// End Popup Calendar
// ******************

