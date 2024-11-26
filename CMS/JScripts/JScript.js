// JScript File

function ChkProjectsCount(objProjectsId)
{
    var varTotalProjects = 0;
    
    for(var i=0; i < document.forms[0].elements.length-1; i++)
    {
        var Cid = document.forms[0].elements[i];
        
        var Type = document.forms[0].elements[i].type;
        if(Type == 'checkbox' && Cid.id.indexOf('chkSelect',0) > 0)
        {
           if(Cid.checked==true)
           {
                varTotalProjects += 1
           }
        }
        
      
        
       
    }
    
    objProjectsId.value = varTotalProjects;
}



function fnAddress(objChkAddress, objPerAptNumber, objPerCity, objPerCountry, objPerState, objPerStreetAddess, objPerTelephone, objPerZip, objTempAptNumber, objTempCity, objTempCountry, objTempState, objTempStreetAddress, objTempPhone, objTempZip)
{
//    alert('v');
    if(objChkAddress.checked==true)
    {
        objTempAptNumber.value = objPerAptNumber.value;
        objTempCity.value = objPerCity.value;
        objTempCountry.value = objPerCountry.value;
        objTempPhone.value = objPerTelephone.value;
        objTempState.value = objPerState.value;
        objTempStreetAddress.value = objPerStreetAddess.value;
        objTempZip.value = objPerZip.value;
    }
    else
    {
        objTempAptNumber.value = "";
        objTempCity.value = "";
        objTempCountry.value = "";
        objTempPhone.value = "";
        objTempState.value ="";
        objTempStreetAddress.value = "";
        objTempZip.value = "";
    }
    
}

function fnSubmit(objBloodRelation, objClasifications,objCrime,objPaidInten,objPhysicalDisability,objRelation,objEmployedwith,objRelativeName ,objCrime,objAgency,objDradLawSchool,objPhysicalDisblty,objTotalProjects,objBloodrelation,objclassification,objcrime,objdisability,objpaidintern,objMessage,objBloodrelationMsg,objclassificationMsg,objcrimeMsg,objdisabilityMsg,objpaidinternMsg)
{
    alert('hi');
    
 }
 
 
 
// function MoveOption(objSourceElement,  objTargetElement,hiddenfield)  
//   {    
//     var aryTempSourceOptions = new Array();  
//     var x = 0;
//      //looping through source element to find selected options
//         for (var i = 0; i < objSourceElement.length; i++) 
//        {
//          if (objSourceElement.options[i].selected) 
//          {
//          //need to move this option to target element
//           var intTargetLen = objTargetElement.length++;   
//           objTargetElement.options[intTargetLen].text = objSourceElement.options[i].text;                
//           objTargetElement.options[intTargetLen].value = objSourceElement.options[i].value;
//             
//           }
//            else 
//            {   
//          //storing options that stay to recreate select element
//           var objTempValues = new Object();                
//           objTempValues.text = objSourceElement.options[i].text;                
//           objTempValues.value = objSourceElement.options[i].value;                
//           aryTempSourceOptions[x] = objTempValues;                
//           x++;            
//            }        
//        }
//        
//        //resetting length of source
//         objSourceElement.length = aryTempSourceOptions.length;
//         //looping through temp array to recreate source select element 
//          for (var i = 0; i < aryTempSourceOptions.length; i++) 
//       {            
//          objSourceElement.options[i].text = aryTempSourceOptions[i].text;            
//          objSourceElement.options[i].value = aryTempSourceOptions[i].value;            
//          objSourceElement.options[i].selected = false;        
//       }    
//    }


function
MoveOption(objSourceElement, objTargetElement,hiddenfield,direction,hiddenback) 
{ 
var aryTempSourceOptions = new Array(); 
var x = 0; 
//looping through source element to find selected options 
for (var i = 0; i < objSourceElement.length; i++) 
{
if (objSourceElement.options[i].selected) 
{
//need to move this option to target element 
var intTargetLen = objTargetElement.length++; 
objTargetElement.options[intTargetLen].text = objSourceElement.options[i].text; 
objTargetElement.options[intTargetLen].value = objSourceElement.options[i].value;
if (direction == 'F') 
{
if( hiddenfield.value == '') 
{
hiddenfield.value = objSourceElement.options[i].value + 
','; 
}
else 
{
hiddenfield.value = hiddenfield.value + objSourceElement.options[i].value + 
',' ; 
}
}
}
else 
{ 
//storing options that stay to recreate select element 
var objTempValues = new Object(); 
objTempValues.text = objSourceElement.options[i].text; 
objTempValues.value = objSourceElement.options[i].value; 
aryTempSourceOptions[x] = objTempValues; 
x++; 
} 
}
//resetting length of source 
objSourceElement.length = aryTempSourceOptions.length;
//looping through temp array to recreate source select element 
if (direction == 'B') 
{
hiddenback.value = 1
hiddenfield.value = 
''; 
}
for (var i = 0; i < aryTempSourceOptions.length; i++) 
{ 
objSourceElement.options[i].text = aryTempSourceOptions[i].text; 
objSourceElement.options[i].value = aryTempSourceOptions[i].value; 
objSourceElement.options[i].selected = 
false; 
if (direction == 'B') 
{
hiddenfield.value = objSourceElement.options[i].value + 
',' + hiddenfield.value; 
}
} 
}