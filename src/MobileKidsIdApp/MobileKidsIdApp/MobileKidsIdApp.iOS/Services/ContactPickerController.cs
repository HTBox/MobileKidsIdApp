using Contacts;
using ContactsUI;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace MobileKidsIdApp.iOS.Services
{
    public sealed class ContactPickerController : CNContactPickerViewController
    {
        internal ContactPickerController(ContactPickerDelegate cpDelegate)
        {
            base.Delegate = cpDelegate;
        }
        public override ICNContactPickerDelegate Delegate
        {
            get
            {
                return base.Delegate;
            }

            set
            {
                base.Delegate = value;
            }
        }

    //    public Task<MediaFile> GetResultAsync() =>
    //((MediaPickerDelegate)Delegate).Task;
    }

    //public class ContactPickerDelegate : CNContactPickerDelegate
    //{
    //    #region Constructors
    //    public ContactPickerDelegate()
    //    {
    //    }

    //    public ContactPickerDelegate(IntPtr handle) : base(handle)
    //    {
    //    }
    //    #endregion

    //    #region Override Methods
    //    public override void ContactPickerDidCancel(CNContactPickerViewController picker)
    //    {
    //        // Raise the selection canceled event
    //        RaiseSelectionCanceled();
    //    }

    //    public override void DidSelectContact(CNContactPickerViewController picker, CNContact contact)
    //    {
    //        // Raise the contact selected event
    //        RaiseContactSelected(contact);
    //    }

    //    public override void DidSelectContactProperty(CNContactPickerViewController picker, CNContactProperty contactProperty)
    //    {
    //        // Raise the contact property selected event
    //        RaiseContactPropertySelected(contactProperty);
    //    }
    //    #endregion

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


    //    internal MediaPickerController(MediaPickerDelegate mpDelegate)
    //    {
    //        base.Delegate = mpDelegate;
    //    }

    //    /// <summary>
    //    /// Deleage
    //    /// </summary>
    //    public override NSObject Delegate
    //    {
    //        get { return base.Delegate; }
    //        set
    //        {
    //            if (value == null)
    //                base.Delegate = value;
    //            else
    //                throw new NotSupportedException();
    //        }
    //    }

    //    /// <summary>
    //    /// Gets result of picker
    //    /// </summary>
    //    /// <returns></returns>
    //    public Task<MediaFile> GetResultAsync() =>
    //        ((MediaPickerDelegate)Delegate).Task;
    //}
}
