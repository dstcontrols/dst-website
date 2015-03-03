/*
 ______ _____   _______ _______ _______ _______ ______ _______ 
|   __ \     |_|    ___|_     _|   |   |       |   __ \   _   |
|    __/       |    ___| |   | |       |   -   |      <       |
|___|  |_______|_______| |___| |___|___|_______|___|__|___|___|

P L E T H O R A T H E M E S . C O M                   (c) 2014

FILE DESCRIPTION: EMAIL SUBMISSION SCRIPT v.1.0.1 (CLIENT-SIDE)

*/

$(document).ready(function() {
		       
    "use strict";
		       
    $('#submit_btn').click(function(){ 
        // GET INPUT FIELD VALUES
        var user_name       = $('#name').val(); 
        var user_email      = $('#email').val();
        var user_subject    = $('#subject').val();
        var user_message    = $('#message').val();
        var output;
        var notice          = $("#notice");
        var $req_fields     = "Please fill in all the fields.";
        // SIMPLE VALIDATION AT CLIENT'S END 
        var proceed = true;
        
        if ( notice.is(":visible") ) notice.hide();

        if ( "" == user_name || "" == user_email || "" == user_subject || "" == user_message ){

               notice.removeClass().html($req_fields).addClass("alert alert-warning alert-dismissable").fadeIn(400);
               proceed = false;

          }
        
        if(user_name==""){ 
            $('#name').css('border-color','red'); 
            proceed = false;
        }
        if(user_email==""){ 
            $('#email').css('border-color','red'); 
            proceed = false;
        }
        if(user_subject=="") {    
            $('#subject').css('border-color','red'); 
            proceed = false;
        }
        if(user_message=="") {  
            $('#message').css('border-color','red'); 
            proceed = false;
        }

        // LOOKS GOOD! PROCEED
        if( proceed ) 
        {
            // DATA TO BE SENT TO SERVER SCRIPT
            var post_data = {
                'userName': user_name, 
                'userEmail': user_email, 
                'userSubject': user_subject, 
                'userMessage': user_message
            };
            // AJAX POST TO SERVER
            $.post('contact.php', post_data, function(response){  
                // LOAD JSON DATA FROM SERVER AND OUTPUT MESSAGE
                if(response.type == 'error')
                {
                    output = response.text;
            		notice.removeClass().html(output).addClass("alert alert-warning alert-dismissable").fadeIn(400);

                } else {

                    output = response.text;
                    // RESET ALL INPUT FIELD VALUES
                    $('#contact_form input').val(''); 
                    $('#contact_form textarea').val(''); 
            		notice.removeClass().html(output).addClass("alert alert-success alert-dismissable").fadeIn(400);
                }
            }, 'json');
            
        }
    });
    
    // RESET PREVIOUSLY SET BORDER COLORS AND HIDE MESSAGE ON .keyup()
    $("#contact_form input, #contact_form textarea").keyup(function(e) { 
        $(this).css('border-color',''); 
    });
    
});
