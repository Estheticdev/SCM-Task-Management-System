<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddData.aspx.cs" Inherits="SCM_Activities.AddData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <script type="text/javascript" src="js/Custom.js"></script>

    <script>

        $(document).ready(function () {
            var _t1 = $("#txtTotal");
            var _t2 = $("#txtTotalP");
            $(_t2).focusout(function () {
                if (_t1.val() === _t2.val()) {
                    return alert('Total Of Category HDs are equal to Total of Priorty HDs');
                }
                return alert('No match');
            });
        });



        $(document).ready(function () {
        
            


            var maxlen = 3;
            $('#txtBuilds').keypress(function (k) {
                if ($(this).val().length >= maxlen) {
                    k.preventDefault();
                    alert('Number Limitation Maximum = ' + maxlen)
                }
            })

            $('#txtFault').keypress(function (k) {
                if ($(this).val().length >= maxlen) {
                    k.preventDefault();
                    alert('Number Limitation Maximum = ' + maxlen)
                }
            })

            $('#txtModification').keypress(function (k) {
                if ($(this).val().length >= maxlen) {
                    k.preventDefault();
                    alert('Number Limitation Maximum = ' + maxlen)
                }
            })

            $('#txtDataCorrection').keypress(function (k) {
                if ($(this).val().length >= maxlen) {
                    k.preventDefault();
                    alert('Number Limitation Maximum = ' + maxlen)
                }
            })

            $('#txtEnhancement').keypress(function (k) {
                if ($(this).val().length >= maxlen) {
                    k.preventDefault();
                    alert('Number Limitation Maximum = ' + maxlen)
                }
            })

            $('#txtOptimization').keypress(function (k) {
                if ($(this).val().length >= maxlen) {
                    k.preventDefault();
                    alert('Number Limitation Maximum = ' + maxlen)
                }
            })

            $('#txtOthers').keypress(function (k) {
                if ($(this).val().length >= maxlen) {
                    k.preventDefault();
                    alert('Number Limitation Maximum = ' + maxlen)
                }
            })

            $('#txtCritical').keypress(function (k) {
                if ($(this).val().length >= maxlen) {
                    k.preventDefault();
                    alert('Number Limitation Maximum = ' + maxlen)
                }
            })

            $('#txtModerate').keypress(function (k) {
                if ($(this).val().length >= maxlen) {
                    k.preventDefault();
                    alert('Number Limitation Maximum = ' + maxlen)
                }
            })

            $('#txtMinor').keypress(function (k) {
                if ($(this).val().length >= maxlen) {
                    k.preventDefault();
                    alert('Number Limitation Maximum = ' + maxlen)
                }
            })

            $('#txtInternalCR').keypress(function (k) {
                if ($(this).val().length >= maxlen) {
                    k.preventDefault();
                    alert('Number Limitation Maximum = ' + maxlen)
                }
            })

            $('#txtGAP').keypress(function (k) {
                if ($(this).val().length >= maxlen) {
                    k.preventDefault();
                    alert('Number Limitation Maximum = ' + maxlen)
                }
            })

            $('#txtJiraIssues').keypress(function (k) {
                if ($(this).val().length >= maxlen) {
                    k.preventDefault();
                    alert('Number Limitation Maximum = ' + maxlen)
                }
            })

            $('#txtUATIssues').keypress(function (k) {
                if ($(this).val().length >= maxlen) {
                    k.preventDefault();
                    alert('Number Limitation Maximum = ' + maxlen)
                }
            })

            $('#txtEffor').keypress(function (k) {
                if ($(this).val().length >= maxlen) {
                    k.preventDefault();
                    alert('Number Limitation Maximum = ' + maxlen)
                }
            })

        })
    </script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center; background-color:black;width:50%;margin-left:25%">
    
            <div style="background-color:lightblue;text-align: center;padding:20px;">

            <div>
    
        <asp:Label ID="Label1" runat="server" Text="Project Type"></asp:Label>
       <asp:DropDownList ID="txtProject" runat="server" Height="23px" Width="150px">
       
        </asp:DropDownList>
         
        <asp:Label ID="Label2" runat="server" Text="Client Name"></asp:Label>
               <asp:DropDownList ID="txtClient" runat="server" Height="23px" Width="150px">
 
        </asp:DropDownList>
                </div>
        <br />

      &nbsp;
                <asp:Label ID="Label3" runat="server" Text="Release or Patch Number"></asp:Label>
       
                 <asp:TextBox ID="txtRelease" runat="server" Width="315px" ></asp:TextBox>
 
&nbsp;<br />
        <br />
                <div>
        <asp:Label ID="Label4" runat="server" Text="Primary"></asp:Label>
        <asp:DropDownList ID="drpPrimary" runat="server" Height="23px" Width="150px">
 
        </asp:DropDownList>
        

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Secondary <asp:DropDownList ID="drpSecondary" runat="server" Height="23px" Width="150px">
 
        </asp:DropDownList>
              </div>
                
                <br />
               
                 <div>
       
       Status        <asp:DropDownList ID="drpStatus" runat="server" Height="23px" Width="150px">
  
        </asp:DropDownList>   
    
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp
       
        <asp:Label ID="Label29" runat="server" Text="Total Builds"></asp:Label>
        <asp:TextBox ID="txtBuilds" runat="server"  TextMode="Number" Height="18px" Width="150px"></asp:TextBox>
                    

                </div>
                
                 </div>
            
            
        <br />

        <br />
            <div style="background-color: lightblue;text-align: center;padding:20px;">

        <asp:Label ID="Label5" runat="server" Text="Planned Code Freeze"></asp:Label>
        <asp:TextBox ID="txtCodeFreeze" runat="server" Width="160px" placeholder="mm/dd/yyyy" Textmode="Date" ReadOnly = "false"></asp:TextBox>
        
        <script>
   $(function () {
      $(".timepicker").timepicker({
         minuteStep: 15
      });
   })
</script>
        <asp:Label ID="Label7" runat="server" Text="Time"></asp:Label>
<asp:TextBox ID="txtCodeFreezeTime" data-provide="timepicker" Width="160px" placeholder="6:00 PM" text="6:00 PM" onfocus="if (this.value == '6:00 PM')  this.value ='';" CssClass="timepicker" runat="server"  />

         <br />

        <br />&nbsp; 
       <asp:Label ID="Label8" runat="server" Text="Actual Code Freeze"></asp:Label>
        <asp:TextBox ID="txtActualCodeFreeze" runat="server" Width="160px" placeholder="mm/dd/yyyy" Textmode="Date" ReadOnly = "false"></asp:TextBox>
        
  
        <asp:Label ID="Label9" runat="server" Text="Time"></asp:Label>
<asp:TextBox ID="txtActualCodeFreezeTime" data-provide="timepicker" Width="160px" placeholder="6:00 PM" text="6:00 PM" onfocus="if (this.value == '6:00 PM')  this.value ='';" CssClass="timepicker" runat="server" />

         <br />

        <br />&nbsp; &nbsp; 

               <asp:Label ID="Label10" runat="server" Text="Planned Shipment"></asp:Label>
        <asp:TextBox ID="txtPlannedShipment" runat="server" Width="160px" placeholder="mm/dd/yyyy" Textmode="Date" ReadOnly = "false"></asp:TextBox>
        

        <asp:Label ID="Label11" runat="server" Text="Time"></asp:Label>
<asp:TextBox ID="txtPlannedShipmentTime" data-provide="timepicker" Width="160px" placeholder="6:00 PM" text="6:00 PM" onfocus="if (this.value == '6:00 PM')  this.value ='';" CssClass="timepicker" runat="server" />

                 <br />

        <br />&nbsp; &nbsp; &nbsp; 

               <asp:Label ID="Label12" runat="server" Text="Actual Shipment"></asp:Label>
        <asp:TextBox ID="txtActualShipment" runat="server" Width="160px" placeholder="mm/dd/yyyy" Textmode="Date" ReadOnly = "false"></asp:TextBox>
        
 
        <asp:Label ID="Label13" runat="server" Text="Time"></asp:Label>
<asp:TextBox ID="txtActualShipmentTime" data-provide="timepicker" Width="160px" placeholder="6:00 PM" text="6:00 PM" onfocus="if (this.value == '6:00 PM')  this.value ='';" CssClass="timepicker" runat="server" />
</div>
         <br />

        <br />
             
                 <div>
          

<div style="background-color: lightblue;text-align: center;padding:20px;">
    
    <table style="width:100%;padding-left:0%;">
        <tr  style="text-align:left">
            <td style="width:50%;">
               <div style="text-align: left;padding:5px;">

            <asp:Label ID="Label15" runat="server"  Text="Category HD's"></asp:Label>
    </div>
            
                <table style="padding-left:2%">
                    <tr>
                        <td>
                            <div style="float:left">
                            <div style="float:left;">
             <asp:Label ID="Label16" runat="server" Text="Fault:"></asp:Label> 
                                </div>
               <div style="float:right;padding-left:68px">          
            <asp:TextBox ID="txtFault" runat="server" TextMode="Number"  MaxLength="3" Height="21px" Width="40px" OnTextChanged="txtFault_TextChanged" AutoPostBack="true"></asp:TextBox>
                 </div> 
</div>
             <div style="float:right;">               
            <asp:Label ID="Label28" runat="server" Text="Modification:"></asp:Label>                                                
            <asp:TextBox ID="txtModification" runat="server" TextMode="Number" MaxLength="3" Height="21px" Width="40px" OnTextChanged="txtModification_TextChanged" AutoPostBack="true"></asp:TextBox>
                 </div>
                            
</td></tr>
                   <tr><td>
                        <div style="float:left">
    <div style="float:left;">
            <asp:Label ID="Label20" runat="server" Text="Data Correction:"></asp:Label>
        </div>
    <div style="float:right">
            <asp:TextBox ID="txtDataCorrection" runat="server" TextMode="Number" MaxLength="3" Height="21px" Width="40px" OnTextChanged="txtDataCorrection_TextChanged" AutoPostBack="true"></asp:TextBox>
        </div>
                            </div>
                        <div style="float:right;">
                        <div style="float:left;">
            <asp:Label ID="Label17" runat="server" Text="Enhancement:"></asp:Label>
        </div>
    <div style="float:right">
            <asp:TextBox ID="txtEnhancement" runat="server" TextMode="Number" MaxLength="3" Height="21px" Width="40px" OnTextChanged="txtEnhancement_TextChanged" AutoPostBack="true"></asp:TextBox>
        </div>
                            </div>

</td></tr> <tr>  <td>
                        <div style="float:left">
    <div style="float:left;">
            <asp:Label ID="Label19" runat="server" Text="Optimization:"></asp:Label>
        </div>
    <div style="float:right;padding-left:18px">
            <asp:TextBox ID="txtOptimization" runat="server" TextMode="Number" MaxLength="3" Height="21px" Width="40px" OnTextChanged="txtOptimization_TextChanged" AutoPostBack="true"></asp:TextBox>
        </div>
                            </div>
                        <div style="float:right;">
                        <div style="float:left;">
            <asp:Label ID="Label23" runat="server" Text="Others:"></asp:Label>
        </div>
    <div style="float:right">
            <asp:TextBox ID="txtOthers" runat="server" TextMode="Number" MaxLength="3" Height="21px" Width="40px" OnTextChanged="txtOthers_TextChanged" AutoPostBack="true"></asp:TextBox>
        </div>
                            </div>
</td></tr> <td>
    <div style="float:left;">  
            <asp:Label ID="Label25" runat="server" Text="Total:"></asp:Label>
        </div>
     <div style="float:right">
            <asp:TextBox ID="txtTotal" runat="server" ReadOnly="true" Height="21px" Width="180px" ></asp:TextBox>
           </div>    
          </td>
                    
                    </tr>

                </table>
            </td>
            
            <td>
                <div style="text-align: left;padding:10px;">

            <asp:Label ID="Label6" runat="server"  Text="Priority-HD's"></asp:Label>
    </div>
            
                 <table style="padding-left:5%">
                    <tr>
                        <td>
                            <div style="float:left">
                            <div style="float:left;">
             <asp:Label ID="Label14" runat="server" Text="Critical:"></asp:Label> 
                                </div>
               <div style="float:right;padding-left:50px">          
            <asp:TextBox ID="txtCritical" runat="server" TextMode="Number" MaxLength="3" Height="21px" Width="40px" OnTextChanged="txtCritical_TextChanged" AutoPostBack="true"></asp:TextBox>
                 </div> 
</div>
             <div style="float:right;padding-left:18px">               
            <asp:Label ID="Label18" runat="server" Text="Moderate:"></asp:Label>                                                
            <asp:TextBox ID="txtModerate" runat="server" TextMode="Number" MaxLength="3" Height="21px" Width="40px" OnTextChanged="txtModerate_TextChanged" AutoPostBack="true"></asp:TextBox>
                 </div>
                            
</td></tr>
                   <tr><td>
                        <div style="float:left">
    <div style="float:left;">
            <asp:Label ID="Label21" runat="server" Text="Minor:"></asp:Label>
        </div>
    <div style="float:right;padding-left:58px">
            <asp:TextBox ID="txtMinor" runat="server" TextMode="Number" MaxLength="3" Height="21px" Width="40px" OnTextChanged="txtMinor_TextChanged" AutoPostBack="true"></asp:TextBox>
        </div>
                            </div>
                        <div style="float:right;">
                        <div style="float:left;">
            <asp:Label ID="Label22" runat="server" Text="Total:"></asp:Label>
        </div>
    <div style="float:right">
            <asp:TextBox ID="txtTotalP" runat="server" ReadOnly="true" Height="21px" Width="40px"></asp:TextBox>
        </div>
                            </div>

</td></tr> <tr>  <td>
                                                <div style="float:left">
    <div style="float:left;">
            <asp:Label ID="Label24" runat="server" Text="Internal CR's:"></asp:Label>
        </div>
    <div style="float:right;padding-left:14px">
            <asp:TextBox ID="txtInternalCR" runat="server" TextMode="Number" MaxLength="3" Height="21px" Width="40px"></asp:TextBox>
        </div>
                            </div>
                        <div style="float:right;">
                        <div style="float:left;">
            <asp:Label ID="Label30" runat="server" Text="GAP's:"></asp:Label>
        </div>
    <div style="float:right">
            <asp:TextBox ID="txtGAP" runat="server" TextMode="Number" MaxLength="3" Height="21px" Width="40px"></asp:TextBox>
        </div>
                            </div>
</td></tr> <td>
                          <div style="float:left">
    <div style="float:left;">
            <asp:Label ID="Label31" runat="server" Text="Jira Issues:"></asp:Label>
        </div>
    <div style="float:right;padding-left:32px">
            <asp:TextBox ID="txtJiraIssues" runat="server" TextMode="Number" MaxLength="3" Height="21px" Width="40px"></asp:TextBox>
        </div>
                            </div>
                        <div style="float:right;">
                        <div style="float:left;">
            <asp:Label ID="Label32" runat="server" Text="UAT Issues:"></asp:Label>
        </div>
    <div style="float:right">
            <asp:TextBox ID="txtUATIssues" runat="server" TextMode="Number" MaxLength="3" Height="21px" Width="40px"></asp:TextBox>
        </div>
                            </div>
          </td>
                    
                    </tr>

                </table>

            </td>
        </tr>
    </table>
   
    
 
    
    </div>
                     
                             
    <br />
            <br />
    <div style="background-color: lightblue;text-align: center;padding:20px;">
                    <asp:Label ID="Label26" runat="server" Text="Comments:"></asp:Label>
                    <asp:TextBox ID="txtComments" runat="server" Height="51px" style="margin-left: 0px" Width="348px"></asp:TextBox>
        
        <div>

                               <asp:Label ID="Label27" runat="server" Text="Effor (Hours):"></asp:Label>
                    <asp:TextBox ID="txtEffor" runat="server" TextMode="Number" MaxLength="3" Height="21px" style="margin-top: 10px" Width="330px"></asp:TextBox>
        


                               <br />
            <br />
                               <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                               <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                               <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                                 <asp:HiddenField ID="hfRecordNumber" runat="server" />
            <br />
            <asp:Label ID="lblSuccessMessage" runat="server" ForeColor="Green" Text=""></asp:Label>
        <br />
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Text=""></asp:Label>

        <br />
            <br />
                  <%-- <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="false" DataKeyNames="RecordNumber"  AllowPaging="True" PageSize="5" OnPageIndexChanging ="gvContact_SelectedIndexChanged" PageIndex="788">
            <Columns>
                <asp:BoundField DataField="ProjectName" HeaderText="Project Type" />
                <asp:BoundField DataField="client" HeaderText="Client" />
                <asp:BoundField DataField="Pro_Rel_Pat_number" HeaderText="Release or Patch"  />
                <asp:BoundField DataField="primary_name" HeaderText="Primary"  />
                <asp:BoundField DataField="secondary_name" HeaderText="Secondary"  />
                <asp:BoundField DataField="shipped" HeaderText="Status"  />
                <asp:BoundField DataField="actual_build" HeaderText="Total Builds"  />
                <asp:BoundField DataField="Plan_Codefreeze" HeaderText="Planned Code Freeze"  />
                <asp:BoundField DataField="time_planned_code_freeze" HeaderText="Time"  />
                <asp:BoundField DataField="actual_codefreeze" HeaderText="Actual Code Freeze"  />
                <asp:BoundField DataField="time_actual_code_freeze" HeaderText="Time"  />
                <asp:BoundField DataField="plan_shipment" HeaderText="Planned Shipment"  />
                <asp:BoundField DataField="time_planned_shipment" HeaderText="Time"  />
                <asp:BoundField DataField="actual_shipment" HeaderText="Actual Shipment"  />
                <asp:BoundField DataField="time_actual_shipment" HeaderText="Time"  />
                <asp:BoundField DataField="fault" HeaderText="Fault"  />
                <asp:BoundField DataField="modification" HeaderText="Modification"  />
                <asp:BoundField DataField="datacorrection" HeaderText="Data Correction"  />
                <asp:BoundField DataField="enhacement" HeaderText="Enhancement"  />
                <asp:BoundField DataField="optimization" HeaderText="Optimization"  />
                <asp:BoundField DataField="others" HeaderText="Others"  />
                <asp:BoundField DataField="total_category_hd" HeaderText="Total"  />
                <asp:BoundField DataField="crittical" HeaderText="Critical"  />
                <asp:BoundField DataField="moderate" HeaderText="Moderate"  />
                <asp:BoundField DataField="minor" HeaderText="Minor"  />
                <asp:BoundField DataField="total_priory_hd" HeaderText="Total"  />
                <asp:BoundField DataField="internal_cr" HeaderText="Internal CR's"  />
                <asp:BoundField DataField="gaps" HeaderText="GAP's"  />
                <asp:BoundField DataField="jira_issue" HeaderText="Jira Issues"  />
                <asp:BoundField DataField="uat_issue" HeaderText="UAT Issues"  />
                <asp:BoundField DataField="comments" HeaderText="Comments"  />
                <asp:BoundField DataField="effor_hours" HeaderText="Effor(Hours)"  />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" CommandArgument='<%# Eval("RecordNumber") %>' OnClick="lnk_OnClick" runat="server">View</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>--%>

                              <%-- <br />
                               <asp:Label ID="lblCount" runat="server" Text="Displaying"></asp:Label>--%>

        </div>

    </div>

                 </div>

        </div>
    </form>
</body>
</html>
