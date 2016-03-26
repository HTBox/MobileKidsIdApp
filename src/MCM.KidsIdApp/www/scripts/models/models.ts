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
    photo?: ResourceReference
    contact?: ResourceReference
    version?: EntityHistoryToken    
}

interface PersonDescription{
    id : string
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
    description: string
    resource : ResourceReference
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

interface ChildDetails extends Person {
  //e.g. first name
  givenName: string
  //p - additional - name - other / middle name
  additionalName?: string
  //p - family - name - family(often last) name
  familyName: string
  birthday?: Date
}

interface Child {
    id: string    
    childDetails : ChildDetails
    descriptions?: Array<PersonDescription>
    distinguishingFeatures?: Array<DistinguishingFeature>     
    professionalCareProviders?: Array<CareProvider>
    familyMembers?: Array<FamilyMember>
    friends?: Array<Person>
    medicalNotes?: MedicalNotes    
    checklist?: PreparationChecklist
    documentMetadatas: Array<DocumentMetadata>
}

interface CareProvider extends Person {
    clinicName?: string
    careRoleDescription: string // physician, dentist, etc. (Might be pointed to a known enumeration later.)
}

interface FamilyMember extends Person{
    relation?: string
}


interface DocumentMetadata {
    description: string;
    fileName: string;
    thumbnailFileName: string;
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

interface ApplicationData {
    userApplicationProfile: UserApplicationProfile
    Family: Family
}