function privateOwned() {

    var Checkfield = Xrm.Page.getAttribute("sonade_privateowned").getValue();
    if (Checkfield == false) {
        Xrm.Page.getControl("sonade_libraryowner").setVisible(false);
        Xrm.Page.getAttribute("sonade_libraryowner").setValue(null);
    }

    if (Checkfield == true) {
        Xrm.Page.getControl("sonade_libraryowner").setVisible(true);
    }

}

function dateOpened() 
{
    var currentDate = new Date();

    var selectedDate = new Date(Xrm.Page.getAttribute("sonade_dateopened").getValue());

    if (selectedDate > currentDate) {
        Xrm.Page.getControl("sonade_dateopened").setNotification("This date is in the future , please select another date");
    }
    else {
        Xrm.Page.getControl("sonade_dateopened").clearNotification();
    }
}