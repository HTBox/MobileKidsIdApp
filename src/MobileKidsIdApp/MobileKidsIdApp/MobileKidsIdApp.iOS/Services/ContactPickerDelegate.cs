using ContactsUI;
using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using Contacts;
using UIKit;
using System.Threading.Tasks;
using MobileKidsIdApp.ViewModels;

namespace MobileKidsIdApp.iOS.Services
{
    //internal class ContactPickerDelegate : CNContactPickerDelegate
    //{
    //    #region Constructors
    //    public ContactPickerDelegate(IntPtr handle) : base(handle)
    //    {
    //    }

    //    protected ContactPickerDelegate(NSObjectFlag t) : base(t)
    //    {
    //    }
    //    #endregion

    //    public override void DidSelectContact(CNContactPickerViewController picker, CNContact contact)
    //    {
    //        // Raise the contact selected event
    //        RaiseContactSelected(contact);
    //    }


    //    #region Events
    //    public delegate void SelectionCanceledDelegate();
    //    public event SelectionCanceledDelegate SelectionCanceled;

    //    internal void RaiseSelectionCanceled()
    //    {
    //        if (this.SelectionCanceled != null) this.SelectionCanceled();
    //    }

    //    public delegate void ContactSelectedDelegate(CNContact contact);
    //    public event ContactSelectedDelegate ContactSelected;

    //    internal void RaiseContactSelected(CNContact contact)
    //    {
    //        if (this.ContactSelected != null) this.ContactSelected(contact);
    //    }

    //    public delegate void ContactPropertySelectedDelegate(CNContactProperty property);
    //    public event ContactPropertySelectedDelegate ContactPropertySelected;

    //    internal void RaiseContactPropertySelected(CNContactProperty property)
    //    {
    //        if (this.ContactPropertySelected != null) this.ContactPropertySelected(property);
    //    }
    //    #endregion
    //}
}
