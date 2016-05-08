using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class StaticContent : BindableObject
    {
        private HtmlWebViewSource _htmlSource;
        public HtmlWebViewSource HtmlSource
        {
            get { return _htmlSource; }
            private set { _htmlSource = value; OnPropertyChanged("HtmlSource"); }
        }

        private void SetSource(string html)
        {
            HtmlSource = new HtmlWebViewSource();
            HtmlSource.Html = html;
        }

        public StaticContent(string contentName)
        {
            switch (contentName)
            {
                case "abduction":
                    SetSource(@"
<div>
  <p>If an estranged parent or former spouse has abducted your child, call the police immediately.</p>
  <p>If you live in Minnesota, tell them you believe that he or she has violated MN State Statute 609.26 (all 50 states have laws making it a felony to take a child with the purpose of depriving a parent of their parental rights).</p>
  <p>Under Minnesota law, it is a crime for a parent to take a child even if they have sole of joint custody or if custody has not been determined. This is a complicated law and many police officers are not familiar with it. If you have trouble filing a police report, contact Missing Children Minnesota right away. If you have reason to believe that the parent or family member that took the child may take them out of the United States, please refer to the International Child Abduction section of this ap as well.</p>
  <p>If you are outside the state of Minnesota, call AMECO <a href='tel:+18772632620'>(877) 263-2620</a> for the AMECO affiliated organization nearest you.</p>
  <p>If parents were not married when the child was conceived or born, or if parents have never been married, custody is automatically with the mother under Minnesota law. The father does not have custody unless there is a custody order or agreement on file with the court. MN Statute details are here: https://www.revisor.mn.gov/statutes/?id=257.541</p>
  <p>It is a criminal offense for a parent or other family member to take or keep the child from their lawful parent with the intent to deprive that parent of his or her parental rights. If your child is taken, retained, or concealed from you, (especially in violation of a court order or on-file custody agreement) call and report this to the police then contact the National Center for Missing and Exploited Children at 1-800-THE-LOST (1-800-843-5678), as well as AMECO at (877) 263-2620 for the AMECO affiliated organization nearest you.  MN Statute details are here: https://www.revisor.mn.gov/statutes/?id=609.26</p>
  <p>Under 42 U.S. Code SS 5772 A “Missing Child” is defined as an individual less than 18 years of age whose whereabouts are unknown to such individual’s legal custodian.</p>
  <p>Under the National Child Search Assistance Act of 1990, NO law enforcement agency can establish a waiting period to take a missing child report. The name and identifying information of the child must be entered into the National Crime Information Center (NCIC) Missing Person’s file immediately upon taking a report.</p>
  <div>
    <h4>Parental Abduction Prevention Tips</h4>
    <ol>
      <li>Get professional legal help to create a detailed custody order or agreement that specifies who has custody, what the child’s residential arrangements will be, what the conditions of visitation are, what the conditions are for either parent to remove the child from the state, and which specifically prohibits a parent removing the child from the state for the purposes of establishing residence for the child in another state without the permission of the other parent.</li>
      <li>Abide by the custody order or agreement yourself, and document any significant violations of the order or agreement by the other party. If you have concerns about allowing the child to go with the other parent for their court-ordered parenting time, be sure to involve someone who can document the conditions under which you are refusing to allow the parenting time.</li>
      <li>Be alert for any sudden and dramatic changes in the other parent’s life (loss of job, selling the home, breaking a lease, closing bank accounts, etc.)</li>
      <li>Take any abduction threats seriously, and inform the courts as well as the police. Contact your attorney for advice.</li>
      <li>If you believe that the other parent has taken the child and intends to deprive you of your parental rights, do not delay. Call the police, and ask that they make a report as well as entering your child and their description into the FBI’s National Crime Information Center (NCIC) right away. There does not need to be a criminal warrant to enter your child as missing.</li>
      <li>If the other parent is a citizen of another country, your child may have dual nationality. Contact the embassy of that country and inquire about their passport requirements for minors.</li>
    </ol>
  </div>
</div>
");
                    break;
                case "amberalert":
                    SetSource(@"
<div>
  <p>AMBER Alerts can only be requested by Law Enforcement. A very small percentage of missing child cases qualify for an AMBER Alert.</p>
  <p>In Minnesota, the criteria are:</p>
  <ol>
    <li>The child must be under the age of 18 (17 years old or younger).</li>
    <li>Law Enforcement must believe that the child has been abducted.</li>
    <li>Law Enforcement must believe that the child is in serious danger of bodily harm or death.</li>
    <li>There must be enough descriptive information about the victim and the abductor for the public to be of help in locating the child.</li>
    <li>The child’s information must be entered in the National Crime Information Center (NCIC) and be flagged as a child abduction.</li>
  </ol>
  <p>If your child is not issued an AMBER Alert, it does not mean that your child is not missing, that the police are not looking for your child, or that nobody is taking your child’s case seriously. All it means is that law enforcement has decided that AMBER Alert is not the right tool for finding your child and bringing them home. There are still many tools that law enforcement, you, and your team of advocates and volunteers can do to bring your child home.</p>
</div>

");
                    break;
                case "disasterprep":
                    SetSource(@"
<div>
  <p>Here are some resources to help you and your family know what to do should your family become separated in a disaster.</p>

  <p>The CDC has an excellent and detailed resource on how to prepare your family in the event of a disaster.</p>
  <a href='http://emergency.cdc.gov/preparedness/index.asp'>http://emergency.cdc.gov/preparedness/index.asp</a>

  <p>A contact card is a really good way to start. These cards can be placed in wallets, backpacks, inside phone cases (between the phone and the case). It’s a great way to make sure that your family members all have the info they need to reunite with you in a disaster</p>
  <a href='http://www.ready.gov/sites/default/files/documents/files/Family_Emegency_Plan.pdf'>http://www.ready.gov/sites/default/files/documents/files/Family_Emegency_Plan.pdf</a>

  <p>In particular, think about these things:</p>
  <ol>
    <li>Does your city, school system and employer have a disaster preparedness guide?</li>
    <li>Do you know what will happen if you need to be evacuated? </li>
    <li>If your children need to be evacuated from school?<li>
    <li>Have you signed up for your city’s Reverse 911 and Code Red systems, so that you will be notified in the case of an emergency?</li>
    <li>If you are signed up, is your information current? Consider checking to be sure.</li>
  </ol>
  <p>Quickly familiarizing yourself with this information will go a long way toward reunifying with your family after a mass disaster.</p>
</div>

");
                    break;
                case "dna":
                    SetSource(@"
<div>
  <p>A DNA sample is one of the best tools you can have in an identification kit. DNA is the accepted standard for identifying people who cannot or will not identify themselves. Fingerprints are great to have, but should be taken by a trained professional. It is fairly easy to take and prepare a DNA sample, and if properly collected and stored, it will last indefinitely.</p>

  <p>Read these instructions all the way through from start to finish before beginning.</p>

  <p>You will need:</p>
  <ol>
    <li>A Q-Tip from a new, sealed package; just make sure the cotton end is untouched. If you are using a double-ended Q-Tip, clip off one end.</li>
    <li>A standard letter-sized envelope marked with the child’s sex, birth date, social security number, and the date the sample was taken.</li>
    <li>A plastic freezer bag.</li>
    <li>A small, clean, dry glass container that is shorter than the Q-Tip is tall. A small drinking glass should work fine.</li>
    <li>Nitrile gloves</li>
  </ol>

  <p>What to Do:</p>
  <ol>
    <li>Make sure that the child does NOT eat or drink anything for a half-hour before giving the sample, and place gloves on hands.</li>
    <li>Place the cotton end of the Q-Tip in the child’s mouth, between the gums and the cheek, the lower jaw towards the back will give a better sample. Twist the tip around a half dozen times; making sure it makes contact with the gum.</li>
    <li>Repeat step #2 on the other side of the mouth.</li>
    <li>Place the Q-Tip in the glass container so that the cotton tip is sticking out of the top. Allow to air dry for half an hour (make sure you DO NOT blow on the Q-Tip). Make sure it does not touch anything. Allow to dry naturally.</li>
    <li>Once the Q-Tip is dry, place the Q-tip in the paper envelope. Seal the envelope with tape (Do not lick! You don’t want to get YOUR DNA on it.) Place the envelope into the freezer bag, and place the freezer bag into the freezer.</li>
  </ol>
  <p>Note: Clean fingernail and toenail clippings, hair (at least 10-20 strands with follicle still attached) and baby teeth can also be used, but will not provide as good a DNA sample. Bandages with blood from a cut or scrape will work as well. Wear gloves while collecting all samples, and store all samples in a sealed paper envelope in a labeled plastic freezer bag in the freezer.</p>
</div>

");
                    break;
                case "international":
                    SetSource(@"
<div>
  <p>If you believe that your child may be taken out of the country by their abductor, you will want to have these resources at the ready:</p>
  <ol>
    <li>A court order that prohibits the child’s removal from the court’s jurisdiction.</li>
    <li>A list of phone numbers for the Airport Police at the airports where your child is most likely to be taken in order to leave the country.</li>
    <li>A list of the phone numbers for the Corporate Security Officers for the airlines that the other parent is most likely to use to leave the country.</li>
    <li>The numbers to the embassy offices where the other parent would most likely go to apply for a passport for your child.</li>
  </ol>

  <p>If your child is a U.S. Citizen under the age of 18, you can set up a Passport Issuance Alert, to alert you if the abductor applies for a U.S. passport for your child.</p>

  <div>
    Children’s Passport Issuance Alert Program (CPIAP)
    <a href='mailto:preventabduction@state.gov'>preventabduction@state.gov</a>
    phone: <a href='tel:+18884074747'>1-888-407-4747</a>
    fax:  202-736-9133
  </div>

  <div>
    U.S. Department of State
    Overseas Citizen Services, Office of Children’s Issues
    2201 “C” Street NW
    Washington, DC, 20520
  </div>

  <p>If the other parent is a citizen of another country, your child may have dual nationality. Contact the embassy of that country and inquire about their passport requirements for minors.</p>

  <p>Call the State Department at 1-888-407-4747 and request help.</p>
</div>

");
                    break;
                case "missing":
                    SetSource(@"
<div>
  <ol>
    <li>Try to remain calm. Quickly search the immediate area, including anywhere your child could have fallen asleep, hidden, or got into but couldn’t get out of (old refrigerator, cupboard, car trunk, closets, swimming pool, etc.) both inside and outside.  Check with neighbors and your child’s neighborhood friends.</li>
    <li>CALL POLICE IMMEDIATELY. Ask them to send an officer. There is never a waiting period for filing a missing person report on a child. After calling the police, stay by the phone for messages while others continue the search. Stay where you told police you would be so they can find you when they arrive.</li>
    <li>If your child disappears in a public place, such as at a store or mall, contact the manager or security, give them your child’s description, ask them to search and to post an employee at each exit. Call the police, tell them your name, location, that your child is missing and to send an officer to take a report.</li>
    <li>During the next few hours, stay where you are or take a cell phone with you so you can be contacted. Organize people to help in the search – friends, family, and neighbors. Get a notebook, and write down all information. If away from home, have someone bring your child’s photos and arrange for someone to take calls at home.</li>
    <li>Register your child with Missing Children Minnesota: call 612-334-9449 or 1-888-RUN-YELL (1-888-786-9355) as soon as you can. We can help with logistics, provide “missing child” posters, contact the media (check with law enforcement first), guidance, advocacy, emotional support, etc.</li>
    <ul>
      <li>Call The National Center for Missing and Exploited Children (1-800-THE-LOST) (1-800-843-5678) to register your child.</li>
      <li>Also call the missing person’s (or children’s) clearinghouse – most states have one. In Minnesota, the missing person’s clearinghouse is a part of the Minnesota Bureau of Criminal Apprehension (the BCA) – call 651-793-1118.</li>
      <li>If your child has run away, call 1-800-RUNAWAY (1-800-786-2929) and register to leave a message for them. This is the National Runaway Safeline, and there are people who can help you as you “talk your child in.” You can also leave messages at most youth shelters in your area, asking the child to call and let you know that they are safe.</li>
    </ul>
    <li>Look for clues to your child’s whereabouts. If your child uses a computer, don’t delete anything. Check your child’s internet browsing history, instant message/chat windows, sent and received emails, etc. for information about where they may be or who they may be with. Also check your child’s cell phone records. Give police access to this information. If you are the person on your child’s phone account use the “find my phone” capability if available, or ask the provider to ping your phone. Give this information to the police.</li>
    <li>Make sure there’s an answering machine or voicemail account on your phone. At the very beginning of the recorded greeting, say “We will accept long distance collect calls.” That way, if your child (or someone with information about your child) calls you collect, the operator will let them leave a message.</li>
    <li>Over the next few days: Stay in touch with police and Missing Children Minnesota, make 10 or more copies of your child’s best, most recent photo, take written notes on what is happening and what police tell you – do not rely on your memory when you are in a crisis. Make sure someone will be answering your home phone or that calls are being forwarded to your cell phone in case your child or someone with information calls.</li>
    <li>Make good use of helping hands. Ask someone to help you contact friends, family, church and community groups for help and support. They can help with distributing posters, running errands, preparing meals, etc. Make sure the volunteers who will be in your home are people you are comfortable with. Also, it’s very important for you to rest – volunteers can take over for you from time to time so you can take care of yourself.</li>
    <li>Until your child is found: distribute posters and keep in touch with police and Missing Children Minnesota (and other agencies) on a regular basis. You may need to seek counseling to help you and your family through the hard times. Make plans for what to do when your child is found.</li>
    <li>When your child is found: Call missing children agencies to close your case. Take posters down. Follow through with the plans you made for what to do when your child is found</li>
  </ol>
</div>

");
                    break;
                case "runaway":
                    SetSource(@"
<div>
  <div>Definition of runaway Youth:</div>
  <div>A person under the age of 18 who absents himself or herself from home or place of legal residence without the permission of a parent or legal guardian.</div>

  <ol>
    <li>Check in with the people your child knows who may have been in contact with your child. This includes their friends, friend’s parents, school officials, bus driver, neighbors, an employer, relatives, or anyone else you would expect to have had recent contact with them. Ask them to let you know if they hear from your child.</li>
    <li>Report your child missing to the local Police Department or Sheriff’s Office. Have an officer come to your home to take the report.</li>
    <li>Federal Law mandates that there is NO waiting period to make a missing child report. You do not have to wait any amount of time before making a report, and officers cannot require you to wait. If the officer does not give you information on next steps and how to follow up, ask him to provide you with that information.</li>
    <li>Provide the officer with a recent photo of your child, and ask where to send the information in your Child ID Kit record.</li>
    <li>Help the officer access any social media, electronic devices, or communications that your child uses. If you or the other parent are the account holder on your child’s phone, contact your provider for location information on their phone.</li>
    <li>Keep a Notebook, and record all information on the investigation. Write down the officer’s name, badge number, contact phone number, and the police report number. Keep any papers that you get in a single envelope, folder, or document holder.</li>
    <li>Write down who you talk to and what they tell you. Also note date and time. Get their name and number if you don’t already have it.</li>
    <li>Make sure that your Law Enforcement enters your child’s name and description into the National Crime Information Center (NCIC). Ask them for your Child’s NICIC number, and make sure to write it down in your notebook.</li>
    <li>Federal Law (The Missing Children Act of 1982) says that a child must be entered in NCIC immediately. This means within two hours of taking the report. If your local law enforcement will not enter the child in NCIC, your local FBI office will.</li>
    <li>Request that the police forward the necessary information to the Minnesota State Missing and Unidentified Person’s Clearinghouse. In Minnesota, the Clearinghouse is operated by the Bureau of Criminal Apprehension (BCA).</li>
    <li>Contact Missing Children Minnesota at (612) 334-9449 or 1-888-RUN-YELL (1-888-786-9355).</li>
    <li>Contact the National Center for Missing and Exploited Children (NCMEC) at 1-800-THE-LOST (1-800-843-5678).</li>
    <li>Contact the National Runaway SafeLine at 1-800-RUNAWAY (1-800-786-2929) ask if your child has left a message, and leave a message for your child.</li>
    <li>Call or check local spots your child may frequent. Leave messages for them at local shelters for runaway youth. Call local Emergency Rooms or Hospitals.</li>
    <li>Put up posters in areas preferred by your child. If you find that your posters are being removed, it may be an indication that your child is in that area. NOTE: It is not permitted to place any kind of notice on MTC bus shelters or buildings.</li>
    <li>Put a message on your phone that you will accept collect calls, as well as a message to your child that will be inviting to them.</li>
    <li>Revisit social media and your child’s contacts frequently to see if any new information has arisen. Give all information to the Law Enforcement person assigned to your child’s case.</li>
    <li>When your child returns home, contact all organizations and agencies working on your child’s case and let them know they can close their records.</li>
    <li>Follow the plans that you have made for when your child returns home. This may include reunification therapy, implementing alternative education plans, etc.</li>
  </ol>
</div>

");
                    break;
                case "safety":
                    SetSource(@"
<div>
  <div>
    <h4>Safer Kids know:</h4>
    <ul>
      <li>Their full name, address and phone number</li>
      <li>The full names and contact info for all their parents</li>
      <li>How to dial 911 in an emergency</li>
      <li>How to make a collect call</li>
      <li>How to use a rotary dial phone</li>
      <li>To use the “buddy system” – it is safer to play, bike, or walk with others</li>
      <li>How to not reveal that they are home alone even over the phone or the internet (role-playing this is helpful for practice)</li>
      <li>To not answer the door if they are home alone</li>
      <li>To not go to anyone’s house unless they tell their caregiver or parent</li>
      <li>To ALWAYS get permission before accepting a ride, from anyone including people they know</li>
      <li>To always talk to parents, police, school officials about suspicious incidences, and things that just don’t seem quite right</li>
      <li>To avoid the “help lure” and ask their parent or caregiver before giving help or aid to anyone, even people they know</li>
      <li>That running away is dangerous, doesn’t solve problems, and usually makes things worse. It is safer to ask for help from your adults</li>
      <li>They have a right to use the phone in an emergency, and don’t need to ask permission</li>
      <li>Nobody has a right to touch the private parts of your body, except for medical reasons. Then, a trusted adult should be present, and it shouldn’t be a secret.</li>
      <li>All touch has to be OK with BOTH people. If a kind of touch is not OK with you, you have a right to say “no” and to get help.</li>
      <li>The difference between “secrets” and “surprises”.  Secrets between kids and their caregivers are not OK, and things get worse the longer they are kept. Surprises are temporary, and when they end, everyone is happy. If your child is every told that something bad will happen if he or she tells, they should know to tell you right away.</li>
    </ul>
  </div>

  <div>
    <h4>Safer Parents know:</h4>
    <ul>
      <li>To not let their children go alone to another part of the store when shopping.</li>
      <li>To ask for references for people caring for your child (and check them out).  Never accept any unaccountable behavior. Make sure that the caregiver understands that they are not to leave your child with, or let your child go with, anyone without your permission. They must get permission every time, even if you have said that a person is OK in the past.</li>
      <li>Where their children are at all times, and teach them to check in with a parent whenever plans change.</li>
      <li>Know the full names and contact information of their children’s friends, and their friend’s parents.</li>
      <li>Know their school’s policy of parental notification, and make sure that the school has up-to-date contact information in case of emergency or unplanned absence.</li>
      <li>To ask “why” when someone shows their child too much attention, or seems to have an inappropriately strong or intimate bond with their child.</li>
      <li>Maintain regular phone contact with their child whenever they are away from them. Calling and speaking with the child is better than texting. You can learn a lot more from hearing your child’s voice on the phone than you can from their texts. Texting can supplement your communications, but if a child’s plans change, call them and get the word from them in a voice call.</li>
      <li>To never label their child’s clothing where it is visible to others. This puts a child on a first-name basis with the whole world.</li>
      <li>To check and keep locks on windows and doors secure and in good repair.</li>
      <li>To talk to their children about the behaviors that other people exhibit, not about “strangers”. Because people they know and should be able to trust will sometimes do unsafe things, and someday a “stranger” may be the only person who can help in a dangerous situation. Also, it is a lot easier to recognize unsafe behavior than it is to tell by looking at someone if they are safe or unsafe.</li>
    </ul>

    <p>More information is available through our programs, but here is an overview (call 612-334-9449 or 1 (888) RUN-YELL (1-888-786-9355) for more info):</p>
  </div>

  <div>
    <h4>RUN, YELL & TELL!®  (ages toddler-7)</h4>
    <p>If anyone tries to give you anything, asks you to go somewhere with them, say “I have to ask First!” And RUN to the person taking care of you, and ask if it’s OK.</p>
    <p>If someone tries to grab you, touch you in a way that is not OK, make you go away with them, or makes you feel scared, “icky” or confused:</p>
    <ul>
      RUN to where there are people
      YELL in a loud voice “Help!  This is not OK!” Or something that will let people know you are in trouble.
      TELL an adult what happened to you. If that adult does not help enough to make you feel safe, tell another adult, and KEEP TELLING until you get the help you need.
    </ul>
    <p>If someone does something bad to you, it is not your fault. Talk to a trusted adult and ask for help.</p>
  </div>

  <div>
    <h4>I Want to Be S.A.F.E.R.!® (ages 8-12)</h4>
    <p>Buddy system: We are safer with other people. Stick together and don’t go off alone.</p>

    <p>Check System</p>
    <ul>
      <li>CHECK IN with whoever is taking care of you often and give them updates whenever plans change.</li>
      <li>They should know where you are, where you are going, who you are with, how you are getting there, and how you will get back.</li>
      <li>CHECK IT OUT with a trusted adult if something does not seem right. Listen to your instincts if you find yourself having an “uh-oh feeling” or thinking to yourself “That’s weird….”</li>
      <li>CHECK UP on your friends if something doesn’t seem right, or if you get separated. Call and make sure everyone got home OK (voice is better than text). If not, make sure their adults know that there is something wrong, and all the information that you had the last time you saw them. If your friend’s behavior is off, or odd or weird – if something doesn’t seem right, discuss it with a trusted adult.</li>
    </ul>
  </div>
  <div>
    <h4>Erica’s Choices® (ages 13-18)</h4>
    <p>Making safe choices is easier if you have the skills that you need to step back and think before acting. Deciding to run is not a safe choice. It does not solve problems, and often makes problems worse.</p>

    <p>If you are thinking about running away, find a trusted adult or councilor to talk to. If you don’t know who to talk to or are not sure how to start the conversation, you can call 1-800-RUNAWAY (1-800-786-2929) for help understanding your safer alternatives.</p>

    <p>Children need to learn several skills to make them less likely to choose running away as an alternative to working out their problems.</p>

    <p>They need the ability to face problems with confidence that they can access whatever resources (including their adults) they will need to overcome a problem.</p>
    <p>They need to have the ability to understand who “owns” the problems that affect them. When children “take on” responsibility for the problems of their adults, the situation can be overwhelming for them.</p>
    <p>They need to trust that the purpose of discipline is to teach, guide and protect them. If it is out of line with their mistakes and offenses, it will have the opposite effect.</p>
    <p>They need help practicing using such problem-solving skills as Pro/con charts, flowcharting, polling, journaling, brainstorming and prioritizing to help them keep problems in perspective, understand their priorities, budget their resources, and understand their own needs so that they can communicate them to their adults when asking for help.</p>
  </div>
</div>

");
                    break;
                default:
                    SetSource(@"<div><p>ERROR: content not found</p></div>");
                    break;
            }
        }
    }
}
