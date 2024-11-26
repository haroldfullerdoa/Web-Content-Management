var popWin=null;


function backURL()
{
   // alert("Hi");
    history.back();
}


 
 function trim(str)
{
    if(str == null) return str;
    var i =-1;
    var j = str.length;
    while( isSpace(str.charAt(++i)) && i < j);
    while( isSpace(str.charAt(--j)) && j > i);
    return str.substring(i,++j);
}
function isSpace(ch)
{
    if(ch == ' ' || ch == '\n' || ch == '\t' || ch == '\f'  || ch == '\r') return true;
    else return false;
}


function isDigit(c)
{
   return (c >= '0' && c <= '9')
}

function isAllDigits(str)
{
    for (var i = 0; i < str.length; i++)
        if ( !isDigit(str.charAt(i)) ) return false;
    return true;
}
function allowFloat(evt){
    
    if(evt.keyCode == 46 || evt.keyCode == 8 || evt.keyCode == 9 || evt.keyCode == 110)
    {
         return true;
    }     
    else if(evt.keyCode > 95 && evt.keyCode < 106)
    {
        return true;
    }
    else if(evt.keyCode ==37 || evt.keyCode == 39)
    {
        return true;
    }
    else if(evt.keyCode == 190) return true;
    else if(evt.keyCode < 48 || evt.keyCode > 57 ) evt.returnValue = false;
    return true;
}

function checkNumberField(obj, objname)
{
    if(!isAllDigits(obj.value))
    {
        alert(objname);
        obj.focus();
        obj.select();
        return false;
    }
    return true;
}

function checkNumberFieldGivenByName(obj, objname)
{
    if(!isAllDigits(document.getElementById(obj).value))
    {
        alert(objname);
        document.getElementById(obj).focus();
        document.getElementById(obj).select();
        return false;
    }
    return true;
}

function allowDigits(evt)
{
    
    if(evt.keyCode == 8 || evt.keyCode == 9 || evt.keyCode == 46)
    {
        return true;
    }
    else if(evt.keyCode ==37 || evt.keyCode == 39)
    {
        return true;
    }
    else if(evt.keyCode > 95 && evt.keyCode < 106)
    {
        return true;
    }
    else if(evt.keyCode < 48 || evt.keyCode > 57)
	{
		evt.returnValue = false;
    }
    //document.forms[0].hdnIsDataSaved.value='True';
    return true;
}

function popup(url)
{
    window.open(url,'Notes','width=350, height=250, scrollbars=1, resizable=no, status=0, top=150, left=300');
}


function positionInfo(object) {

  var p_elm = object;

  this.getElementLeft = getElementLeft;
  function getElementLeft() {
    var x = 0;
    var elm;
    if(typeof(p_elm) == "object"){
      elm = p_elm;
    } else {
      elm = document.getElementById(p_elm);
    }
    while (elm != null) {
      x+= elm.offsetLeft;
      elm = elm.offsetParent;
    }
    return parseInt(x);
  }

  this.getElementWidth = getElementWidth;
  function getElementWidth(){
    var elm;
    if(typeof(p_elm) == "object"){
      elm = p_elm;
    } else {
      elm = document.getElementById(p_elm);
    }
    return parseInt(elm.offsetWidth);
  }

  this.getElementRight = getElementRight;
  function getElementRight(){
    return getElementLeft(p_elm) + getElementWidth(p_elm);
  }

  this.getElementTop = getElementTop;
  function getElementTop() {
    var y = 0;
    var elm;
    if(typeof(p_elm) == "object"){
      elm = p_elm;
    } else {
      elm = document.getElementById(p_elm);
    }
    while (elm != null) {
      y+= elm.offsetTop;
      elm = elm.offsetParent;
    }
    return parseInt(y);
  }

  this.getElementHeight = getElementHeight;
  function getElementHeight(){
    var elm;
    if(typeof(p_elm) == "object"){
      elm = p_elm;
    } else {
      elm = document.getElementById(p_elm);
    }
    return parseInt(elm.offsetHeight);
  }

  this.getElementBottom = getElementBottom;
  function getElementBottom(){
    return getElementTop(p_elm) + getElementHeight(p_elm);
  }
}

function CalendarControl() {

  var calendarId = 'CalendarControl';
  var currentYear = 0;
  var currentMonth = 0;
  var currentDay = 0;

  var selectedYear = 0;
  var selectedMonth = 0;
  var selectedDay = 0;

  var months = ['January','February','March','April','May','June','July','August','September','October','November','December'];
  var dateField = null;

  function getProperty(p_property){
    var p_elm = calendarId;
    var elm = null;

    if(typeof(p_elm) == "object"){
      elm = p_elm;
    } else {
      elm = document.getElementById(p_elm);
    }
    if (elm != null){
      if(elm.style){
        elm = elm.style;
        if(elm[p_property]){
          return elm[p_property];
        } else {
          return null;
        }
      } else {
        return null;
      }
    }
  }

  function setElementProperty(p_property, p_value, p_elmId){
    var p_elm = p_elmId;
    var elm = null;

    if(typeof(p_elm) == "object"){
      elm = p_elm;
    } else {
      elm = document.getElementById(p_elm);
    }
    if((elm != null) && (elm.style != null)){
      elm = elm.style;
      elm[ p_property ] = p_value;
    }
  }

  function setProperty(p_property, p_value) {
    setElementProperty(p_property, p_value, calendarId);
  }

  function getDaysInMonth(year, month) {
    return [31,((!(year % 4 ) && ( (year % 100 ) || !( year % 400 ) ))?29:28),31,30,31,30,31,31,30,31,30,31][month-1];
  }

  function getDayOfWeek(year, month, day) {
    var date = new Date(year,month-1,day)
    return date.getDay();
  }

  this.clearDate = clearDate;
  function clearDate() {
    dateField.value = '';
    hide();
  }

  this.setDate = setDate;
  function setDate(year, month, day) {
    if (dateField) {
      if (month < 10) {month = "0" + month;}
      if (day < 10) {day = "0" + day;}

      var dateString = month+"/"+day+"/"+year;
      dateField.value = dateString;
      
      hide();
    }
    return;
  }

  this.changeMonth = changeMonth;
  function changeMonth(change) {
    currentMonth += change;
    currentDay = 0;
    if(currentMonth > 12) {
      currentMonth = 1;
      currentYear++;
    } else if(currentMonth < 1) {
      currentMonth = 12;
      currentYear--;
    }

    calendar = document.getElementById(calendarId);
    calendar.innerHTML = calendarDrawTable();
  }

  this.changeYear = changeYear;
  function changeYear(change) {
    currentYear += change;
    currentDay = 0;
    calendar = document.getElementById(calendarId);
    calendar.innerHTML = calendarDrawTable();
  }

  function getCurrentYear() {
    var year = new Date().getYear();
    if(year < 1900) year += 1900;
    return year;
  }

  function getCurrentMonth() {
    return new Date().getMonth() + 1;
  } 

  function getCurrentDay() {
    return new Date().getDate();
  }

  function calendarDrawTable() {

    var dayOfMonth = 1;
    var validDay = 0;
    var startDayOfWeek = getDayOfWeek(currentYear, currentMonth, dayOfMonth);
    var daysInMonth = getDaysInMonth(currentYear, currentMonth);
    var css_class = null; //CSS class for each day

    var table = "<table cellspacing='0' cellpadding='0' border='0'>";
    table = table + "<tr class='calendarHeader'>";
    table = table + "  <td colspan='2' class='previous'><a href='javascript:changeCalendarControlMonth(-1);'>&lt;</a> <a href='javascript:changeCalendarControlYear(-1);'>&laquo;</a></td>";
    table = table + "  <td colspan='3' class='title'>" + months[currentMonth-1] + "<br>" + currentYear + "</td>";
    table = table + "  <td colspan='2' class='next'><a href='javascript:changeCalendarControlYear(1);'>&raquo;</a> <a href='javascript:changeCalendarControlMonth(1);'>&gt;</a></td>";
    table = table + "</tr>";
    table = table + "<tr><th>S</th><th>M</th><th>T</th><th>W</th><th>T</th><th>F</th><th>S</th></tr>";

    for(var week=0; week < 6; week++) {
      table = table + "<tr>";
      for(var dayOfWeek=0; dayOfWeek < 7; dayOfWeek++) {
        if(week == 0 && startDayOfWeek == dayOfWeek) {
          validDay = 1;
        } else if (validDay == 1 && dayOfMonth > daysInMonth) {
          validDay = 0;
        }

        if(validDay) {
          if (dayOfMonth == selectedDay && currentYear == selectedYear && currentMonth == selectedMonth) {
            css_class = 'current';
          } else if (dayOfWeek == 0 || dayOfWeek == 6) {
            css_class = 'weekend';
          } else {
            css_class = 'weekday';
          }

          table = table + "<td><a class='"+css_class+"' href=\"javascript:setCalendarControlDate("+currentYear+","+currentMonth+","+dayOfMonth+")\">"+dayOfMonth+"</a></td>";
          dayOfMonth++;
        } else {
          table = table + "<td class='empty'>&nbsp;</td>";
        }
      }
      table = table + "</tr>";
    }

    table = table + "<tr class='calendarHeader'><th colspan='7' style='padding: 3px;'><a href='javascript:clearCalendarControl();'>Clear</a> | <a href='javascript:hideCalendarControl();'>Close</a></td></tr>";
    table = table + "</table>";

    return table;
  }

  this.show = show;
function show(field) 
{
    can_hide = 0;
   
    // If the calendar is visible and associated with
    // this field do not do anything.
    
    if (dateField == field) 
    {
     // return;
    }
    else 
    {
      dateField = field;
    }

    if(dateField) {
      try {
        var dateString = new String(dateField.value);
        var dateParts = dateString.split("/");
        
        selectedMonth = parseInt(dateParts[0],10);
        selectedDay = parseInt(dateParts[1],10);
        selectedYear = parseInt(dateParts[2],10);
      } catch(e) {}
    }

    if (!(selectedYear && selectedMonth && selectedDay)) {
      selectedMonth = getCurrentMonth();
      selectedDay = getCurrentDay();
      selectedYear = getCurrentYear();
    }

    currentMonth = selectedMonth;
    currentDay = selectedDay;
    currentYear = selectedYear;

    if(document.getElementById){

      calendar = document.getElementById(calendarId);
      calendar.innerHTML = calendarDrawTable(currentYear, currentMonth);

      setProperty('display', 'block');

      var fieldPos = new positionInfo(dateField);
      var calendarPos = new positionInfo(calendarId);

      var x = fieldPos.getElementLeft();
      var y = fieldPos.getElementBottom();

      setProperty('left', x + "px");
      setProperty('top', y + "px");
 
      if (document.all) {
        setElementProperty('display', 'block', 'CalendarControlIFrame');
        setElementProperty('left', x + "px", 'CalendarControlIFrame');
        setElementProperty('top', y + "px", 'CalendarControlIFrame');
        setElementProperty('width', calendarPos.getElementWidth() + "px", 'CalendarControlIFrame');
        setElementProperty('height', calendarPos.getElementHeight() + "px", 'CalendarControlIFrame');
      }
    }
  }

  this.hide = hide;
  function hide()
  {
        if(dateField) 
        {
              setProperty('display', 'none');
              setElementProperty('display', 'none', 'CalendarControlIFrame');
            
        }
  }

  this.visible = visible;
  function visible() 
  {
    return dateField
  }

  this.can_hide = can_hide;
  var can_hide = 0;
}

var calendarControl = new CalendarControl();

function showCalendarControl(textField)
{
  // textField.onblur = hideCalendarControl;
  
   
  calendarControl.show(textField);
}

function clearCalendarControl() {
  calendarControl.clearDate();
}

function hideCalendarControl() {
  if (calendarControl.visible()) {
    calendarControl.hide();
  }
}

function setCalendarControlDate(year, month, day) {
  calendarControl.setDate(year, month, day);
}

function changeCalendarControlYear(change) {
  calendarControl.changeYear(change);
}

function changeCalendarControlMonth(change) {
  calendarControl.changeMonth(change);
}

document.write("<iframe id='CalendarControlIFrame' src='javascript:false;' frameBorder='0' scrolling='no'></iframe>");
document.write("<div id='CalendarControl'></div>");




function y2k(number) { return (number < 1000) ? number + 1900 : number; }

function monthsahead(noofmonths,dateStr) {
    var today1 = new Date(dateStr);
	 today2 =   (today1.getTime() - 1*24*60*60*1000);
	 var today = new Date(today2);
    var date = new Date(today.getYear(),today.getMonth() + noofmonths,today.getDate(),today.getHours(),today.getMinutes(),today.getSeconds());
	var day		= new String(date.getDate());
	var month	= new String(date.getMonth()+1);
	var year    = y2k(date.getYear());
	if(day.length == 1)
	{
		day = '0'+day;
	}
	if(month.length == 1)
	{
		month = '0'+month;
	}
        
	return month+'/'+day+'/'+year

}

function daysInMonth(month,year)
 {
    var m = [31,28,31,30,31,30,31,31,30,31,30,31];
    if (month != 2) return m[month - 1];
    if (year%4 != 0) return m[1];
    if (year%100 == 0 && year%400 != 0) return m[1];
    return m[1] + 1;
} 

var fnd = "";
    
function searchDropDownList(sel, evt) {
    if (window.event)
    {
         var k = String.fromCharCode(event.keyCode);
        
    }
    else
    {
        var k = String.fromCharCode(evt.which);
    }
    if (k < " " || k > "~")
    {
         return true;
     }    
    if (k == " ")
    {
        fnd = "";
     }   
     else
     {
        fnd += k.toUpperCase();
     }   
     fnDSize = fnd.length;
     
    for (var i=0; i<sel.options.length; i++)
    {
        
        if(sel.options[i].text.toUpperCase().substr(0,fnDSize) == fnd)
        {
            fnd = "";
            break;
        }
        /*if (fnd <= sel.options[i].text.toUpperCase())
        {
            
        } */
        sel.selectedIndex = i;          
    }
    
    /*
    var fnd = "";
function findOption(sel, evt) {
if (window.event) var k = String.fromCharCode(event.keyCode);
else var k = String.fromCharCode(evt.which);
if (k < " " || k > "~") return true;
if (k == " ") fnd = "";
else fnd += k.toUpperCase();
for (var i=0; i<sel.options.length; i++) {
if (fnd <= sel.options[i].text.toUpperCase()) break;
}
sel.selectedIndex = i;
return false;
}
*/
    
    return false;
}
