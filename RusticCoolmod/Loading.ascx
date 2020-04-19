<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Loading.ascx.cs" Inherits="RusticCoolmod.Loading" %>

<asp:Panel ID="Panel1" runat="server" style="margin:0 auto">
    <div style="margin:0 auto; width:50%; margin-top:10%">
        <div class="progress">
        <!--<img src="Assets/source.gif" style="height:150px"/>-->
        <div class="progress-bar progress-bar-striped progress-bar-animated" id="bar" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%"></div>
        </div>
    </div>
</asp:Panel>

<script type="text/javascript">
        function move(i) {
            if (i == 0) {
                i = 1;
                var elem = document.getElementById("bar");
                var width = 1;
                var id = setInterval(frame, 10);
                function frame() {
                    if (width >= 100) {
                        clearInterval(id);
                        i = 0;
                        setTimeout(function () {
                            window.location.replace("Invitado.aspx");
                        }, 1500);
                    } else {
                        width++;
                        elem.style.width = width + "%";
                    }
                }
            }
        }
</script>