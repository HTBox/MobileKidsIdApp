// BASE CLASS DEFINITIONS

// Describes a reference to a file, contact, or foreign entity outside 
// the context of this application.
interface ResourceReference{
    id: string
    resourceType: string
}

// Describes a reference to a file
interface FileReference extends ResourceReference {
    description: string;
    fileName: string;
    thumbnailFileName: string;
}

// Describes a contact
interface ContactReference {
    contactId: string
}

interface Person {    
    id: string    
    contact?: ContactReference
}

interface PhysicalDetails{
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
    gender?: string
    genderIdentity?: string
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
    id : string
    description: string
    photo : FileReference
}

interface PreparationChecklist {
    childPhoto: boolean
    birthCertificate: boolean
    socialSecurityCard: boolean
    physicalDetails: boolean
    distinguishingFeatures: boolean
    friends: boolean
    dna: boolean
    mementos: boolean
    divorceCustodyPapers: boolean
    otherParentsAndFamily: boolean
}

// IMPLEMENTATION CLASSES

interface ChildDetails {
    givenName: string    //e.g. first name
    additionalName?: string    //p - additional - name - other / middle name
    familyName: string    //p - family - name - family(often last) name
    birthday?: Date
    contact? : ContactReference
}

interface Child {
    id: string    
    childDetails: ChildDetails
    physicalDetails?: PhysicalDetails
    distinguishingFeatures?: Array<DistinguishingFeature>
    professionalCareProviders?: Array<CareProvider>
    familyMembers?: Array<FamilyMember>
    friends?: Array<Person>
    medicalNotes?: MedicalNotes    
    checklist?: PreparationChecklist
    documents?: Array<FileReference>
    photos?: Array<FileReference>
}

interface CareProvider extends Person {
    clinicName?: string
    careRoleDescription: string
}

interface FamilyMember extends Person{
    relation?: string
}


// TOP LEVEL STRUCTURES

// root node of the data model that stores the family
// data and is only available after the login process
// is complete (it is in a separate blob on disk)
interface Family{
    children: Array<Child>
}

interface UserApplicationProfile {
  firstUse: Date
  legalAcknowlegeDataSecurityPolicy: boolean
}

// Maps to identity principal provided by credentials provider.
// TODO : Elaborate for token management, sessions, etc.
interface UserIdentity {
  providerName: string
  userIdFromProvider: string
}

// root node of the data model used during the login
// process
interface ApplicationData {
    userApplicationProfile: UserApplicationProfile
    permittedLoginIdentities: Array<UserIdentity>  
}