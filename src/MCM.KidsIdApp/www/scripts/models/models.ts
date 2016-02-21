// BASE CLASS DEFINITIONS
// Describes a reference to a binary file or foreign entity outside the context of this application.
// Ex. Phone Contact, Photo, etc.
interface ResourceReference{
    id: string
    resourceType: string
    version?: EntityHistoryToken 
}

// General entity history and comparison token. (Needs elaboration.)
interface EntityHistoryToken{
    created: Date
    lastModified: Date
    applicationVersion?: string
    version?: string    
}
// Maps to identity principal provided by credentials provider.
// TODO : Elaborate for token management, sessions, etc.
interface UserIdentity{
    id: string
    providerName: string
    created: Date
}

interface Person {    
    id: string    
    //Honorific - prefix - e.g.Mrs., Mr.or Dr.
    honorific?: string
    //e.g. first name
    givenName: string
    //p - additional - name - other / middle name
    additionalName?: string
    //p - family - name - family(often last) name
    familyName: string
    //    p - nickname - nickname / alias / handle
    nickname?: string
    email?: string
    //URL to home page
    url?: string
    addresses?: Array<Address>
    //Telephone number
    tel?: string
    jobTitle?: string
    sex?: string
    genderIdentity?: string
    //Birthday
    bday?: Date
    notes?: string
    photo?: ResourceReference
    contact?: ResourceReference
    version?: EntityHistoryToken    
}

interface PersonDescription{
    height?: string
    weight?: string
    measurementDate?: Date
    hairColor?: string 
    hairStyle?: string 
    eyeColor?: string 
    eyeGlasses?: boolean
    eyeContacts?: boolean
    skinTone?: string
    racialEthnicIdentity?: string 
}

interface MedicalNotes{
    medicAlertInfo?: string
    allergies?: string
    regularMedications?: string
    psychMedications?: string
    inhaler?: boolean
    diabetic?: boolean
    notes?: string
}

interface DistinguishingFeature{
    description: string
    resource : ResourceReference
}

interface Address {
    /// House / apartment number, floor, street name
    streetAddress?: string
    //Additional street details
    extendedAddress?: string
    //post office mailbox
    postOfficeBox?: string
    //city / town / village
    locality?: string
    //state / county / province
    region?: string
    //postal code, e.g.ZIP in the US
    postalCode?: string
    //should be full name of country, country code ok
    countryName?: string
    ////a mailing label, plain text, perhaps with preformatting
    notes?: string    
}

interface PreparationChecklist {
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

interface SharePolicy{
    physicalDescription: boolean
    distinguishingFeatures: boolean
    professionalCareProviders: boolean
    familyMembers: boolean
    friends: boolean
    documents: boolean
    photos: boolean
}

// IMPLEMENTATION CLASSES

interface Child extends Person {
    physicalDescription?: PersonDescription
    distinguishingFeatures?: Array<DistinguishingFeature>     
    professionalCareProviders?: Array<CareProvider>
    familyMembers?: Array<FamilyMember>
    friends?: Array<Person>
    medicalNotes?: MedicalNotes    
    checklist?: PreparationChecklist
}

interface CareProvider extends Person {
    clinicName?: string
    careRoleDescription: string // physician, dentist, etc. (Might be pointed to a known enumeration later.)
}

interface FamilyMember extends Person{
    relation?: string
}


// TOP LEVEL STRUCTURES

interface UserApplicationProfile{
    installed: Date
    firstUse: Date
    legalAcknowlegeDataSecurityPolicy: boolean
    shareEmails?: Array<string>
    loginIdentities: Array<UserIdentity>
    version?: EntityHistoryToken       
}

interface Family{
    id: string    
    permittedLoginIdentities: Array<UserIdentity>  
    children: Array<Child>
    sharePolicy: SharePolicy
    version?: EntityHistoryToken   
}
