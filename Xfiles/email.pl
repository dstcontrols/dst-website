#!/usr/bin/perl
#THE ABOVE LINE NEEDS TO BE EDITED to point to the location of Perl on 
#your system!
#
#FILE: email.pl - Version 1.4
#
#       This perl script generates both the HTML form and email message
#people wish to send you.
#
#       To call this script, just call it as you would any other perl
#script you have on your system. Example:
#       http://www.domain.com/cgi-bin/email.pl
#
#       This script expects its name to be "email.pl"
#
#       What's nice about this script if you can pass in the subject of
#the message. To do so, the URL to this script should look similar to 
#the following:
#
#http://www.domain.com/cgi-bin/email.pl?subject=Hi_there!
#
#       Note the "?subject=" part at the end of the URL. This is required
#in order for the subject to be read. Note that you cannot have any
#spaces in the subject part of the URL. So, the following will not work:
#       ?subject=Testing this script
#
#	The second nice feature is this script is configurable so you can
#specify your own destination email address. For example, you may want to
#use this if you're using this form for more than one person. To specify
#an email address, just append the following to the URL:
#	to=the_email@yourdomain.com
#
#	If you are specifying the "to" and not the subject, then the URL
#should look similar to the following:
#http://www.domain.com/cgi-bin/email.pl?to=me@my.com
#
#	If you want to specift both the subject and the to (destination
#email), then the URL should look similar to:
#http://www..domain.com/cgi-bin/email.pl?subject=Hi!&to=me@my.com
#OR
#http://www..domain.com/cgi-bin/email.pl?to=me@my.com&subject=Hi!
#
#	Note there are NO spaces, and note the ampersand "&" character
#separating the fields!
#
#       Finally, this code is FREE, and comes with absolutely NO
#warranties, either expressed or implied. Feel free to do what you want
#with it. Feel free to build upon it. If you did not copy this code
#from http://www.erols.com/lozinski, you don't have the original.
#
#REVISION HISTORY:
#       06/04/97        Original Version
#	01/11/99	Updated so users can now have a copy
#			of their feedback emailed to them as well.
#	08/27/99	Updated so users can specify a destination 
#			email address besides setting a default one. 
#	09/11/99	Fixed a security hole. If using a previous version, UPGRADE!
#	10/21/99	Added in the SHOW_OPTIONAL_FIELDS value.
#
#CONTACT INFORMATION:   http://www.erols.com/lozinski/email_form.html
#
#Begin the customizable configurations:

#The title of the web page and the text on the "submit" button
my $TITLE = "Send Me Email!";

#The background color of the web page, the normal text color, and the
#text color for the information that is required. Note that these can
#either be in hexidecimal format, or words as the settings below show.
#Note that if you specify the color code in hex, it expects a leading '#'
#pound sign. 
my $BGCOLOR = "#000000";
my $TEXT_COLOR_NORMAL = "#0088FF";
my $REQUIRED_TEXT_COLOR = "yellow";

#The URL to a background picture for the web pages.
my $BACKGROUND_URL = "";

#The URL to the executable directory where this script is located. 
#DO NOT put a trailing slash '/' character!
my $CGI_DIR = "";

#Set to "1" if you want the optional fields shown in the email form.
#Set to "0" (zero) otherwise.
$SHOW_OPTIONAL_FIELDS = 1;

#The location of "sendmail" on your system.
my $sendmail = "/usr/sbin/sendmail";

#The email address where you want all the email from this page sent to if 
#no destination email is supplied by the "to" parameter. NOTE THE BACKSLASH
#CHARACTER "\" BEFORE THE "@" CHARACTER! 
my $destination_email = "eunger\@iname.com";

#### NOTHING BELOW THIS LINE SHOULD NEED TO BE EDITED/CONFIGURED! ####

&print_header;
&get_form_data;
if (!$FORM_DATA{'mail'}) {
        &print_html_form;
} else {
        $error = 0;
        &check_form_data;
        if (!$error) {
                &send_mail;
                &reply_to_user;
        }       
}
exit(0);

######## The Subroutines ########

########
#
#sub print_header
#
#       Just prints out the beginning of any HTML page headers. 
#
########
sub print_header {

print ("Content-type: text/html\n\n");
print ("<HTML>\n<HEAD>\n<TITLE>$TITLE</TITLE>\n</HEAD>\n");
print ("<BODY BGCOLOR=\"$BGCOLOR\" BACKGROUND=\"$BACKGROUND_URL\" ");
print ("TEXT=\"$TEXT_COLOR_NORMAL\">\n");

}#print_header

########
#
#sub get_form_data
#
#       Gets the information submitted, decode it, and put it
#into the $FORM_DATA associative array.
#
#########
sub get_form_data {
        
$request_method = $ENV{'REQUEST_METHOD'};
if ($request_method eq "GET") {
	$form_info = $ENV{'QUERY_STRING'};
} else {
	$size_of_form_information = $ENV{'CONTENT_LENGTH'};
	read (STDIN, $form_info, $size_of_form_information);
}
@key_value_pairs = split (/&/, $form_info);
foreach $key_value (@key_value_pairs) {
	($key, $value) = split (/=/, $key_value);
	$value =~ tr/+/ /;
	$value =~ s/%([\dA-Fa-f][\dA-Fa-f])/pack ("C", hex ($1))/eg;
	if (defined($FORM_DATA{$key})) {
		$FORM_DATA{$key} = join (", ", $FORM_DATA{$key}, $value);
	} else {
		$FORM_DATA{$key} = $value;
	}
}

} #get_form_data

########
#
#sub print_html_form
#
#       This subroutine prints out the HTML form the user fills in to
#send an email message.
#
#########
sub print_html_form {

print <<__END_OF_HTML_CODE__;
<FORM ACTION="$CGI_DIR/email.pl" METHOD="POST">
<INPUT TYPE="hidden" NAME="to" VALUE="$FORM_DATA{'to'}">
<H2>$TITLE</H2>
__END_OF_HTML_CODE__
if ($SHOW_OPTIONAL_FIELDS) {
        print ("<BR><FONT COLOR=\"$REQUIRED_TEXT_COLOR\"><B>All required ");
        print ("information is bolded in this color.</B></FONT>\n");
        print ("Everything else is just for my own curiosity. <BR>");
}
print <<__END_OF_HTML_CODE__;
<TABLE BORDER="0" CELLPADDING="4" CELLSPACING="2">
<TR VALIGN="top">
<TD>
<TABLE>
__END_OF_HTML_CODE__
if ($SHOW_OPTIONAL_FIELDS) {
        print ("<TR VALIGN=\"top\">\n");
        print ("<TD>Your name:</TD>\n");
        print ("<TD><INPUT TYPE=\"text\" NAME=\"users_name\"></TD>\n");
        print ("</TR>\n");
}
print <<__END_OF_HTML_CODE__;  
<TR VALIGN="top">
<TD><FONT COLOR="$REQUIRED_TEXT_COLOR"><B>Your email:</B></FONT></TD>
<TD><INPUT TYPE="text" NAME="users_email">
<FONT COLOR="$REQUIRED_TEXT_COLOR">
<INPUT TYPE="checkbox" NAME="keep_copy" VALUE="1" CHECKED>Have a copy of
your message sent to you? </FONT></TD>
</TR>
</TABLE>
<BR>
__END_OF_HTML_CODE__
if ($SHOW_OPTIONAL_FIELDS) {
        print <<__END_OF_HTML_CODE__;
	<TABLE>
	<TR VALIGN="top">
	<TD>Your country of residence:</TD>
	<TD><INPUT TYPE="text" NAME="users_country"><BR><BR></TD>
	</TR>
	<TR VALIGN="top">
	<TD>Your home State/Province:</TD>
	<TD>
	<INPUT TYPE="radio" NAME="state_usa" VALUE="USA">
	If inside the U.S.:
	<SELECT NAME="state_address1" SIZE="1">
	<OPTION>Alabama
	<OPTION>Alaska
	<OPTION>Arizona
	<OPTION>Arkansas
	<OPTION>Hawaii
	<OPTION>California
	<OPTION>Colorado
	<OPTION>Connecticut
	<OPTION>Delaware
	<OPTION>Florida
	<OPTION>Georgia
	<OPTION>Idaho
	<OPTION>Illinois
	<OPTION>Indiana
	<OPTION>Iowa
	<OPTION>Kansas
	<OPTION>Kentucky
	<OPTION>Louisiana
	<OPTION>Maine
	<OPTION>Maryland
	<OPTION>Massachusetts
	<OPTION>Michigan
	<OPTION>Minnesota
	<OPTION>Mississippi
	<OPTION>Missouri
	<OPTION>Montana
	<OPTION>Nebraska
	<OPTION>Nevada
	<OPTION>New Hampshire
	<OPTION>New Jersey
	<OPTION>New Mexico
	<OPTION>New York
	<OPTION>North Carolina
	<OPTION>North Dakota
	<OPTION>Ohio
	<OPTION>Oklahoma
	<OPTION>Oregon
	<OPTION>Pennsylvania
	<OPTION>Rhode Island
	<OPTION>South Carolina
	<OPTION>South Dakota
	<OPTION>Tennessee
	<OPTION>Texas
	<OPTION>Utah
	<OPTION>Vermont
	<OPTION>Virginia
	<OPTION>Washington
	<OPTION>Washington, D.C.
	<OPTION>West Virginia
	<OPTION>Wisconsin
	<OPTION>Wyoming
	</SELECT><BR>
	<INPUT TYPE="radio" NAME="state_usa"  VALUE="NOT_USA">
	If outside the U.S.:
	<INPUT TYPE="text" NAME="state_address2">
	</TD>
	</TR>
	</TABLE>
	<BR>
__END_OF_HTML_CODE__
}
print <<__END_OF_HTML_CODE__;
<FONT COLOR="$REQUIRED_TEXT_COLOR"><B>Enter the subject of the
message:</B></FONT>
<INPUT TYPE="text" NAME="subject" VALUE="$FORM_DATA{'subject'}"><BR>
<BR>
<FONT COLOR="$REQUIRED_TEXT_COLOR"><B>Please enter your message
below:</B></FONT><BR>
<TEXTAREA NAME="message" ROWS="8" COLS="70"></TEXTAREA>
<BR><BR>
<INPUT TYPE="hidden" NAME="mail" VALUE="1">
<INPUT TYPE="submit" VALUE="$TITLE">
</TD>
</TR>
</TABLE>
<BR>
</FORM>
</BODY>
</HTML>
__END_OF_HTML_CODE__

} #print_html_form

########
#
#sub check_form_data
#
#       This subroutine checks the information submitted via the
#html form to make sure we have all the required information.
#
########
sub check_form_data {

#The array which holds all the error code numbers, and the error message
#associated with that code number.
my      %error_codes = (
                "1"     =>      "You need to enter your email address.",
                "2"     =>      "Your message cannot be sent without a
                                subject.",
                "3"     =>      "You seemed to have forgotten to enter the
                                email message you wish to send.",
                "4"     =>    "For security reasons, you cannot have any of the following characters in your email or subject fields: [ ; < > & \* ` \| ] "
        );

if ($FORM_DATA{'users_email'} !~ /\@/ && 
	$FORM_DATA{'users_email'} !~ /\w/) {
	$error = 1;
} elsif ($FORM_DATA{'subject'} !~ /\w/) {
	$error = 2;
} elsif ($FORM_DATA{'message'} !~ /\w/) {
	$error = 3;
}
if (($FORM_DATA{"subject"} =~ /[\[\;\>\<\&\*\^\$\(\)\`\|\]\']/) || ($FORM_DATA{"to"} =~ /[\[\;\>\<\&\*\^\$\(\)\`\|\]\']/)
	|| ($FORM_DATA{"users_email"} =~ /[\[\;\>\<\&\*\^\$\(\)\`\|\]\']/)) {
	$error = 4;
}
if ($error) {
	print ("<H3>\n");
	print ("Sorry! Your message could not be sent for the ");
	print ("following reasons:<BR> \n");
	print ("<BR>$error_codes{$error}\n<BR>\n<BR>");
	print ("Please hit the back button in your browser to ");
	print ("correct this. Thank you!\n");
	print ("</H3>\n</BODY>\n</HTML>\n");
}

if ($FORM_DATA{'to'} ne "") {
	$destination_email = $FORM_DATA{'to'};
}

} #check_form_data

########
#
#sub send_mail
#
#       This subroutine writes and send the email message. Nothing fancy.
#
########
sub send_mail {

open (MESSAGE, "| $sendmail -t -oi ");
print MESSAGE <<__END_OF_MESSAGE__;
To: $destination_email
From: $FORM_DATA{"users_email"}
Subject: $FORM_DATA{"subject"}

__END_OF_MESSAGE__
if ($FORM_DATA{'users_name'} ne "") {
	print MESSAGE ("$FORM_DATA{'users_name'} - ");
}
print MESSAGE ("$FORM_DATA{'users_email'} filled out the email ");
print MESSAGE ("form on your website.\n");
if ($FORM_DATA{'users_country'} ne "") {
	print MESSAGE ("They are in the country of: $FORM_DATA{'users_country'}\n");
}
if ($FORM_DATA{'state_usa'} =~ /^USA$/i) {
	print MESSAGE ("They are writing from the state of: $FORM_DATA{'state_address1'}\n\n");
} elsif ($FORM_DATA{'state_usa'} =~ /^NOT_USA$/i) {
	print MESSAGE ("They are writing from the province of: $FORM_DATA{'state_address2'}\n\n");
}
print MESSAGE ("The follow is what they had to say:\n\n");
print MESSAGE ("$FORM_DATA{'message'}\n");
close (MESSAGE);
if ($FORM_DATA{'keep_copy'}) {
	open (MESSAGE, "| $sendmail -t -oi ");
	print MESSAGE <<__END_OF_MESSAGE__;
To: $FORM_DATA{"users_email"}
Subject: $FORM_DATA{"subject"}

__END_OF_MESSAGE__
        print MESSAGE ("The following is what you wrote from the ");
	print MESSAGE ("$TITLE webpage...:\n\n");
        print MESSAGE ("$FORM_DATA{'message'}\n");
        close (MESSAGE);
}

} #send_mail

########
#
#sub reply_to_user
#
#       Provided everything submitted from the form checks out ok,
#this subroutine returns an HTML page to the user repeating the
#information they submitted.
#
########
sub reply_to_user {

print ("<B><I>Thank you</I></B> for sending me email!<BR><BR>\n");
print ("Below is a copy of the information you sent me:<BR>\n");
print ("<DL>\n");
if ($FORM_DATA{'users_name'} ne "") {
	print ("<DT><B>Your name:</B>\n<DD>$FORM_DATA{'users_name'}<BR><BR>\n");
}
print ("<DT><B>Your email:</B>\n<DD>$FORM_DATA{'users_email'}<BR><BR>\n"); 
if ($FORM_DATA{'users_country'} ne "") {
	print ("<DT><B>Your country:</B>\n<DD>$FORM_DATA{'users_country'}<BR><BR>\n");
}
if ($FORM_DATA{'state_address1'} ne "" && $FORM_DATA{'state_usa'} =~ /^USA$/i) {
	print ("<DT><B>Your state:</B>\n<DD>$FORM_DATA{'state_address1'}<BR><BR>\n"); 
} elsif ($FORM_DATA{'state_address2'} ne "" && $FORM_DATA{'state_usa'} =~ /^NOT_USA$/i) { 
	print ("<DT><B>Your state:</B>\n<DD>$FORM_DATA{'state_address2'}<BR><BR>\n") if ($FORM_DATA{'state_address2'} ne "");
}
print ("<DT><B>Your message:</B>\n<DD>$FORM_DATA{'message'}<BR><BR>\n");
print ("</DL>\n");
print ("</BODY>\n</HTML>\n");

} #reply_to_user

#FILE: email.pl

