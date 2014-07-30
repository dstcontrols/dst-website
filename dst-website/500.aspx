<script language="CS" runat="server"> 
void Page_Load(object sender, System.EventArgs e)
{      
    Response.StatusCode = 500;
} 
</script>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>OOPS ERROR OCCURED</title>
        <link href='http://fonts.googleapis.com/css?family=Open+Sans:800' rel='stylesheet' type='text/css' />
        <style type="text/css">
            .error-page {
                background: #2dacd4;
                cursor: default;
                left: 0;
                min-height: 100%;
                position: absolute;
                top: 0;
                width: 40%;
            }

            .error-block {
                background: #fff;
                box-shadow: 6px 6px 0 0 rgba(0, 0, 0, 0.1);
                font-family: 'Open Sans', sans-serif;
                font-weight: 800;
                height: 510px;
                margin-top: -255px;
                position: absolute;
                right: -355px;
                text-transform: uppercase;
                top: 50%;
                width: 510px;
            }

            .error-number {
                background: #50badb;
                height: 100%;
                left: 0;
                position: absolute;
                top: 0;
                width: 155px;
                z-index: 2;
            }

            .error-number > span {
                color: #fff;
                display: block;
                font-size: 88px;
                line-height: 80px;
                padding: 70px 0 0 70px;
                text-shadow: 0 -1px 0 #219ac0;
                width: 55px;
                word-wrap: break-word;
            }

            .error-message {
                color: #2dacd4;
                display: block;
                font-size: 80px;
                line-height: 1em;
                padding: 70px 0 0 185px;
                text-shadow: 0 -1px 0 #219ac0;
                word-wrap: break-word;
            }

            .error-message span {
                display: block;
                font-size: 56px;
                line-height: 1.5em;
            }

            .go-back {
                background: url('http://dve9d4b1d190c.cloudfront.net/images/error-bg.png');
                bottom: 0;
                height: 125px;
                left: 0;
                padding: 55px 0 0 0;
                position: absolute;
                width: 100%;
            }

            .go-back span {
                -moz-transition: color 0.2s ease-out;
                -webkit-transition: color 0.2s ease-out;
                color: #38393c;
                font-size: 53px;
                margin: 0;
                text-shadow: 0 -1px 0 #000;
                transition: color 0.2s ease-out;
            }

            .back-button {
                background: url('http://dve9d4b1d190c.cloudfront.net/images/error-back.png') no-repeat 80px 20px;
                display: block;
                padding-left: 185px;
                position: relative;
                text-decoration: none;
                z-index: 3;
            }

            .back-button:hover {
                background-position: 80px -42px;
            }

            .back-button:hover span {
                color: #d91d1d;
                text-shadow: 0 -1px 0 #ac2020;
            }
        </style>
    </head>
    <body>
        <div class="error-page">
            <div class="error-block">
                <div class="error-number">
                    <span>500</span>
                </div>
                <div class="error-message">
                    Oops...
                    Error
                    <span>Occurred</span>
                </div>
                <div class="go-back">
                    <a href="javascript:history.go(-1)" class="back-button"><span>Go Back?</span></a>
                </div>
            </div>
        </div>
    </body>
</html>