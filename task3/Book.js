function complexityChange () 
{
    var pagesNumber = Xrm.Page.getAttribute("sonade_numberofpages").getValue();
    var setComplexity = Xrm.Page.getAttribute("sonade_c");

    if(pagesNumber < 1)
    {
        Xrm.Page.ui.setFormNotification("This is an invalid number of pages", "ERROR");
        setComplexity.setValue(null);
    }

    else if (pagesNumber > 0 && pagesNumber <= 99)
    {
        setComplexity.setValue(976820000);
    }

    else if(pagesNumber > 99 && pagesNumber <= 299 )
    {
        setComplexity.setValue(976820001);
    }

    else if(pagesNumber > 299)
    {
        setComplexity.setValue(976820002);
    }

   
}