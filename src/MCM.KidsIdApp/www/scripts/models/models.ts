interface Data {

    sytemSettings: SystemSettings

    children: Array<Child>

    doctors: Array<Doctor>

    childDoctorLookup: Array<[number, number]>
    
}

interface SystemSettings {
    version: string
}

interface Child extends Person {
    height: string
    weight: string
    measurementDate: Date
    hairColor: string //Dropdown
    hairStyle: string //Dropdown
    eyeColor: string //Dropdown
    glasses: boolean
    contacts: boolean
    skinTone: string //Dropdown
    racialEthnicIdentity: string
    featureDescription: string //Multiple
    featurePhoto: Array<string> //Multiple
    //Feature/description cross reference.
    featureDescriptionCrossReference: Array<string>
    doctorID: number
    medicAlertInfo: string
    allergies: string
    regularMedications: string
    psychMedications: string
    inhaler: boolean
    diabetic: boolean
    dentistID: number

    friendContactKeys: Array<string>
    familyContactKeys: Array<string>
    
    checklist: Checklist
}

interface Doctor extends Person {
    clinicName: string
}

interface Person {
    
    id: number
    
    //Honorific - prefix - e.g.Mrs., Mr.or Dr.
    honorific: string
    //e.g. first name
    givenName: string
    //p - additional - name - other / middle name
    additionalName: string
    //p - family - name - family(often last) name
    familyName: string
    //    p - nickname - nickname / alias / handle
    nickname: string
    email: string
    photo: string
    //URL to home page
    url: string
    //ID of the associated address object.
    addressID: number
    //Telephone number
    tel: string
    jobTitle: string
    sex: string
    genderIdentity: string
    //Birthday
    bday: Date
    note: string
}


interface Address {

    id: number

    /// House / apartment number, floor, street name
    streetAddress: string
    //Additional street details
    extendedAddress: string
    //post office mailbox
    postOfficeBox: string
    //city / town / village
    locality: string
    //state / county / province
    region: string
    //postal code, e.g.ZIP in the US
    postalCode: string
    //should be full name of country, country code ok
    countryName: string
    ////a mailing label, plain text, perhaps with preformatting
    //label: string
}


interface Checklist {
    childPhoto: boolean
    birthCertificate: boolean
    socialSecurityCard: boolean
    measurements: boolean
    distinguishingFeatures: boolean
    friends: boolean
    dna: boolean
    mementos: boolean
    divorceCustodyPapers: boolean
    otherParentsAndFamily: boolean
}

interface Notifications {

}
