
function ItemMinimize(Name) {
if (Name<=13) {
  for(i=1;i<15;i++) {
	var MItem=document.getElementById('IDM_'.concat(i));
	if(MItem==null)
	{
	
	}
	else
	{
        if (i==Name){

			    if (MItem.style.display=='block') {
				    MItem.style.display='none';				
				    break;
    				
			    }
			    else {
				    MItem.style.display='block';
    				break;
			    }
	      }
	    else {
		    MItem.style.display='none';
	    }
	}
  }  
}
else 
{
	var MItem=document.getElementById('IDM_'.concat(Name));	
    if(MItem==null)
    {
    }
    else
    {
			if (MItem.style.display=='') {
				MItem.style.display='none';		
				
			}
			else {
				MItem.style.display='';			
			} 
		}
	}
}
