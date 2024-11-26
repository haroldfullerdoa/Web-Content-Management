<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false" CodeFile="EditStore.aspx.vb" Inherits="CMS_Concessions_EditStore" title="Concessions - Edit Store Locations"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
               // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
           $addHandler($get("btnHideModalPopup_store"), 'click', hideModalPopupViaClient);    
           $addHandler($get("btnHideModalPopup_file"), 'click', hideModalPopupViaClient);       
        }
         
        function hideModalPopupViaClient(ev) {
            ev.preventDefault();        
            var modalPopupBehavior = $find('programmaticModalPopupBehavior_store');
            modalPopupBehavior.hide();        
            modalPopupBehavior = $find('programmaticModalPopupBehavior_file');
            modalPopupBehavior.hide();
        }                  
    </script>


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <div class="tab" style="width: 100%;text-align:left;height:auto; vertical-align:middle;padding: 5px;">
    Change Company:&nbsp;&nbsp;
    <asp:DropDownList ID="dplCompanyName" runat="server" DataSourceID="SqlDataSource1" DataTextField="COMPANY_NAME" DataValueField="COMPANY_ID" AppendDataBoundItems="True" AutoPostBack="True" CausesValidation="false">
       <asp:ListItem  Text=" [Add New Company] " Value="0"></asp:ListItem>
    </asp:DropDownList> 
    </div>

<table width="100%" border="0" cellpadding="2" cellspacing="10" id="TABLE1">
  <tr>
    <td align="left">
    <asp:Label ID="lblMessage" runat="server" text="" EnableViewState="false" BackColor="yellow"></asp:Label> 
    </td>
  </tr>

  <tr>
    <td align="center"><div class="PageTitle">Edit Company &amp; Store Location</div></td>
   </tr>  
  
  
 <tr>
  <td><hr style="size:1px;width:100%;" /></td>
 </tr>
  <tr>
      <td style="width:100%;">  
   
      <asp:FormView ID="FormView1" runat="server" Width="100%" DataSourceID="ObjectDataSource_Company">
        <RowStyle HorizontalAlign="Left" />             
          <ItemTemplate>      
          <p style="text-align:right;"><asp:Button ID="btnEdit"  CssClass="button" runat="server" Text="Edit/Delete Company" CommandName="Edit" CausesValidation="false" EnableViewState="false"  /></p>
          <h2><asp:Label ID="lbCompany_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Company_Name")%>' /></h2>    
          <p><asp:Label ID="lbCompany_Description" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Company_Description").ToString.Replace(VbCrLf, "<br/>")%>' /></p>
          <p><asp:Label ID="lbStore_Type" runat="server" Font-Bold="true" Font-Italic="true" Text='<%#DataBinder.Eval(Container.DataItem,"Store_Type")%>' /></p>
          <p><strong>Contact Information:</strong><br />
          Phone: <asp:Label ID="lbCompany_Phone1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Company_Phone1")%>'/>&nbsp;
          <asp:Label ID="lbCompany_Phone2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Company_Phone2")%>' /><br />
          Web: <asp:HyperLink ID="lkCompany_WebSite" runat="server" NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Company_WebSite")%>' Text='<%#DataBinder.Eval(Container.DataItem,"Company_WebSite")%>' Target="_blank"/></p>
          </ItemTemplate>

        <EditItemTemplate>
           <table width="100%" border="0" cellpadding="2" cellspacing="10" id="TABLE2">
            <tr>
            <td colspan="2" align="left">
             &nbsp;
            <asp:Label ID="lbCompTitle" runat="server" CssClass="PageTitle" >Company Information</asp:Label>  
            </td>
            </tr>
            
          <tr>
            <td align="right" style="width:40%;" class="LoginHeadings"><label>Company Name:</label></td>
            <td style="width:60%;"><asp:TextBox ID="txtCompanyName" runat="server" Width="300px" MaxLength="100" Text='<%#DataBinder.Eval(Container.DataItem,"Company_Name")%>'></asp:TextBox>
            </td>
          </tr>
          
          <tr>
            <td valign="top" align="right" class="LoginHeadings"><label>Company Description:</label></td>
            <td><asp:TextBox ID="txtCompanyDescription" runat="server" Width="300px" Rows="8" MaxLength="2000" TextMode="MultiLine" Wrap="true" Text='<%#DataBinder.Eval(Container.DataItem,"Company_Description")%>' ></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReCompanyDescription" runat="server" ErrorMessage="Company Description is blank" ControlToValidate="txtCompanyDescription">*</asp:RequiredFieldValidator>
            </td>
          </tr>
            
          <tr>
            <td align="right" class="LoginHeadings"><label>Store Type:</label></td>   
            <td><asp:DropDownList ID="dplCompanyType" runat="server" DataSourceID="sqlDataSource3" DataTextField ="STORE_TYPE" DataValueField="STORE_TYPE_ID" SelectedValue='<%#DataBinder.Eval(Container.DataItem,"Store_Type_ID") %>'>
                </asp:DropDownList>    
            </td>
           </tr>
          
            <tr>
               <td align="right" class="LoginHeadings"><label>Company Contact Number:</label></td>
               <td><asp:TextBox ID="txtPhone1" runat="server" Width="175px" MaxLength="30" Text='<%#DataBinder.Eval(Container.DataItem,"Company_Phone1")%>'></asp:TextBox>           
            </td>
            </tr>

            <tr>
               <td align="right" class="LoginHeadings"><label>Alternative Phone Number:</label></td>
               <td><asp:TextBox ID="txtPhone2" runat="server" Width="175px" MaxLength="30" Text='<%#DataBinder.Eval(Container.DataItem,"Company_Phone2")%>'></asp:TextBox>
              </td>
            </tr>  
              
            <tr>
               <td align="right" class="LoginHeadings"><label>Company Web site:</label></td>
               <td><asp:TextBox ID="txtWebsite" runat="server" Width="250px" MaxLength="200" Text='<%#DataBinder.Eval(Container.DataItem,"Company_WebSite")%>'></asp:TextBox>
              </td>
            </tr>    
                 
          <tr>
            <td align="center" colspan="2">
             <asp:Button ID="btnUpdate"  CommandName="Update" CssClass="button" runat="server" Text="Update Company"/>
              &nbsp;&nbsp;
             <asp:Button ID="btnDelete"  CommandName="Delete" CssClass="button" runat="server" Text="Delete Company"/>
             <AspAjax:ConfirmButtonExtender ID="ConfirmButtonExtender1" TargetControlID="btnDelete" ConfirmOnFormSubmit="true" ConfirmText="Are you sure that you want to delete this company?"  runat="server"></AspAjax:ConfirmButtonExtender>
              &nbsp;&nbsp;
             <asp:Button ID="btnCancel"  CommandName="Cancel" CssClass="button" runat="server" Text=" Cancel "/>
              </td>
          </tr>
        </table>  
       </EditItemTemplate>

</asp:FormView>

  </td>
  </tr>
 
 <tr>
  <td><hr style="size:1px;width:100%;" /></td>
 </tr>            
            <tr><%-- image uploading --%> 
                <td>
                <div class="PageTitle" style="float:left"><img src="../Images/attach.gif" alt="attach" /> View Company Attachments (click to open in a new window)</div>
                <div style="text-align:right;float:right;">
                <asp:Button runat="server" ID="btnShowModalPopup_file" Text="Upload File" OnClick="showModalPopup_File" CausesValidation="false" />
                <asp:Button runat="server" ID="hiddenTargetControlForModalPopup_File" style="display:none"/>
                </div>
                
                <br style="clear:both;" />
                <br />
                    <asp:GridView ID="grdPhoto" runat="server" DataSourceID="objectdatasource_files" AutoGenerateColumns="False" 
                    cellpadding="4" BorderWidth="1" CellSpacing="0" DataKeyNames="ID" Width="100%" AllowPaging="True" EmptyDataText="No Files Found">
                <Columns> 
                <asp:TemplateField HeaderText="File" ShowHeader="True" ControlStyle-Width="400">
                    <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" Text='<%#Get_File_Name(DataBinder.Eval(Container.DataItem,"ID"),DataBinder.Eval(Container.DataItem,"Company_File_Data"),DataBinder.Eval(Container.DataItem,"Company_File_Name"),DataBinder.Eval(Container.DataItem,"Company_File_Type"))%>' Width="400px" NavigateUrl='<%#Get_File_URL(DataBinder.Eval(Container.DataItem,"ID"),DataBinder.Eval(Container.DataItem,"Company_File_Name"),DataBinder.Eval(Container.DataItem,"Company_File_Type"))%>' Target="_blank" ToolTip="Click to open in a new window"></asp:HyperLink>
                    </ItemTemplate>
                   </asp:TemplateField>
                   <asp:BoundField DataField="Company_File_Type" HeaderText="Category" />
                   <asp:BoundField DataField="Company_File_Format" HeaderText="Type" />
                   <asp:CommandField HeaderText="Delete" DeleteText="Delete" ButtonType="Button" ShowDeleteButton="true"  />
                  <asp:BoundField DataField="ID" visible="False" />      
                    </Columns>
                    </asp:GridView>
                    
                    
        <AspAjax:ModalPopupExtender runat="server" ID="programmaticModalPopup_File"
            BehaviorID="programmaticModalPopupBehavior_file"
            TargetControlID="hiddenTargetControlForModalPopup_File"
            PopupControlID="plNewFile" 
            BackgroundCssClass="modalBackground"
            DropShadow="True"
            PopupDragHandleControlID="plFileHeader" DynamicServicePath="" Enabled="True">
            </AspAjax:ModalPopupExtender>
                 
        <asp:Panel ID="plNewFile" runat="server" Style="display: none; width:500px;background-color:White;">
            <asp:Panel ID="plFileHeader" runat="server" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;width:500px;">
                <div style="text-align:center;height:25px;vertical-align:middle;">
                    <strong>Upload New File</strong>
                </div>
            </asp:Panel>
                
        
                <br />
            <table width="90%" border="0" cellpadding="2" cellspacing="4">                
                 
                            <tr>
                                <td style="text-align:right; width:30%; vertical-align:top;">
                                    <asp:Label ID="lbFile_Type" runat="server" Text="Upload Category: " CssClass="LoginHeadings"></asp:Label>
                                </td>
                                <td style="text-align:left;width:70%;">&nbsp;
                                   <asp:RadioButtonList ID="rblCategory" runat="server" EnableViewState="false">
                                    <asp:ListItem Value="photo"> Company Photography </asp:ListItem>
                                    <asp:ListItem Value="menu"> Restaurant Menu </asp:ListItem>
                                      <asp:ListItem Value="logo"> Company Logo </asp:ListItem> 
                                      <asp:ListItem Value="offer"> Company Offer </asp:ListItem>                                     
                                    </asp:RadioButtonList>                                    
                                </td>                        
                            </tr>
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label ID="lbFile" runat="server" Text="Choose File: " CssClass="LoginHeadings"></asp:Label>
                                </td>
                                <td>
                                  <input id="fileCompany" type="file" runat="server" />
                                 </td>
                        
                            </tr>                      
                                     
                            <tr>
                                <td align="center" colspan="2"><br /><br />
                                    <asp:Button runat="server" ID="btnNewFile" Text="Upload" OnClick="hideModalPopup_File" />
                                   &nbsp; &nbsp;<input type="button" id="btnHideModalPopup_file" value="Cancel" /></td>
                             </tr>
                             <tr>
                                  <td colspan="2">
                                  <asp:Label  ID="lbFileUpdateMessage" runat="server" Font-Bold="true" ForeColor="red" Text="" EnableViewState="false"  /></td>                        
                             </tr>                 
              </table>   
                            <br />
        </asp:Panel>                       
                    
</td>
            </tr> 
 <tr>
  <td><hr style="size:1px;width:100%;" /></td>
 </tr>
  
  <tr>
      <td style="width:100%;">  
        <div id="location">      
          <div class="PageTitle" style="float:left">Store Locations Information</div>   
                <div style="text-align:right;float:right;">
                <asp:Button runat="server" ID="btnShowModalPopup_Store" Text="Add Store" OnClick="showModalPopup_Store" CausesValidation="false" />
                <asp:Button runat="server" ID="hiddenTargetControlForModalPopup_Store" style="display:none"/>
                </div>
                <br style="clear:both;"/>  
                <br />
               <asp:GridView ID="grdStores" runat="server" AutoGenerateColumns="False" cellpadding="4"               
                DataKeyNames="ID" DataSourceID="ObjectDataSource_Store" forecolor="#333333" Width="100%" 
                EmptyDataText="No Store Location found" HorizontalAlign="Center" AllowSorting="False" AllowPaging="True">
                <FooterStyle backcolor="#507CD1" Font-Bold="True" forecolor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Location" ShowHeader="true">
                    <ItemTemplate>
                    <asp:Label ID="lbStore_Location" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Store_Location")%>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:DropDownList ID="drpStore_Location_Edit" runat="server" DataSourceID="SqlDataSource2" DataTextField="Store_Location" DataValueField="Store_Location_ID"  SelectedValue='<%# Bind("Store_Location_ID") %>'>
                    </asp:DropDownList>
                    </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Store_Phone1" HeaderText="Phone" />       
                    <asp:BoundField DataField="Store_Phone2" HeaderText="2nd Phone" />    
                    <asp:TemplateField ShowHeader="true" HeaderText="Hours">
                    <ItemTemplate>
                    <asp:Label ID="lbHours_Operation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Hours_Operation")%>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="drpHours_Operation_Edit" runat="server" SelectedValue='<%# Bind("Hours_Operation") %>'>
                                <asp:ListItem Value=""> -- select one --- </asp:ListItem>
                                <asp:ListItem>Open 24 hours</asp:ListItem>
                                <asp:ListItem>5 a.m. - 9 p.m.</asp:ListItem>
                                <asp:ListItem>5 a.m. - 10 p.m.</asp:ListItem>
                                <asp:ListItem>5 a.m. - 10:30 p.m.</asp:ListItem>
                                <asp:ListItem>5 a.m. - 11 p.m.</asp:ListItem>
                                <asp:ListItem>5:30 a.m. – 9:00 p.m</asp:ListItem>
                                <asp:ListItem>5:30 a.m. - 9:30 p.m.</asp:ListItem>
                                <asp:ListItem>5:30 a.m. – 11:00 p.m</asp:ListItem>
                                <asp:ListItem>6 a.m. - 8 p.m.</asp:ListItem>
                                <asp:ListItem>6 a.m. - 10 p.m.</asp:ListItem>
                                <asp:ListItem>6 a.m. - 10:30 p.m.</asp:ListItem>
                                <asp:ListItem>6 a.m. - 11 p.m.</asp:ListItem>
                                <asp:ListItem>6:30 a.m. - 9:00 p.m.</asp:ListItem>
                                <asp:ListItem>6:30 a.m. - 10:00 p.m.</asp:ListItem>
                                <asp:ListItem>6:30 a.m. - 11:00 p.m.</asp:ListItem>
                                <asp:ListItem>7 a.m. - 9 p.m.</asp:ListItem>
                                <asp:ListItem>7 a.m. - 10 p.m.</asp:ListItem>
                                <asp:ListItem>7 a.m. - 11 p.m.</asp:ListItem>
                                <asp:ListItem>7:00 a.m. - 10:30 p.m.</asp:ListItem>
                                <asp:ListItem>8:00 a.m. - 10:30 p.m.</asp:ListItem>
                                <asp:ListItem>8 a.m. - 8 p.m.</asp:ListItem>
                                <asp:ListItem>8 a.m. - 10 p.m.</asp:ListItem>
                                <asp:ListItem>8 a.m. - 10:30 p.m.</asp:ListItem>
                                <asp:ListItem>8 a.m. - 11 p.m.</asp:ListItem>
                                <asp:ListItem>9 a.m. - 6 p.m.</asp:ListItem>
                                <asp:ListItem>9 a.m. - 11 p.m.</asp:ListItem>
                                <asp:ListItem>10 a.m. - 12 p.m.</asp:ListItem>
                                <asp:ListItem>12:00 p.m. - 11:00 p.m.</asp:ListItem>      
                                <asp:ListItem>12:30 p.m. - 10:00 p.m.</asp:ListItem>        
                                <asp:ListItem Value=" "> -- None --- </asp:ListItem>                               
                          </asp:DropDownList>
                    </EditItemTemplate>
                    </asp:TemplateField>                                      
                    <asp:BoundField DataField="Seating_Available" HeaderText="Seating" />                   
                    <asp:BoundField DataField="Closed_Renovation" HeaderText="Closed"  />
                       <asp:BoundField DataField="Awarded" HeaderText="Awarded"  />              
                   <asp:CommandField ButtonType="Button" HeaderText="Action" ShowDeleteButton="True"
                        ShowEditButton="True" ShowHeader="True" />
                  
                    <asp:BoundField DataField="ID" visible="False" />      
                </Columns>
                <RowStyle backcolor="#EFF3FB" HorizontalAlign="Left" VerticalAlign="Top" />
                <EditRowStyle backcolor="Yellow" Width="100%" />
                <SelectedRowStyle backcolor="Yellow" Font-Bold="True" forecolor="#333333" />
                <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center" />
                <HeaderStyle backcolor="#507CD1" Font-Bold="True" forecolor="White" />
                <AlternatingRowStyle backcolor="White" />
            </asp:GridView>
            <br />
</div>
         
        <AspAjax:ModalPopupExtender runat="server" ID="programmaticModalPopup_Store"
            BehaviorID="programmaticModalPopupBehavior_store"
            TargetControlID="hiddenTargetControlForModalPopup_Store"
            PopupControlID="plNewStore" 
            BackgroundCssClass="modalBackground"
            DropShadow="True"
            PopupDragHandleControlID="plStoreHeader" DynamicServicePath="" Enabled="True">
            </AspAjax:ModalPopupExtender>
                 
        <asp:Panel ID="plNewStore" runat="server" Style="display: none; width:500px;background-color:White;">
            <asp:Panel ID="plStoreHeader" runat="server" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;width:500px;">
                <div style="text-align:center;height:25px;vertical-align:middle;">
                    <strong>Add New Store</strong>
                </div>
            </asp:Panel>
                
        
                <br />
            <table width="90%" border="0" cellpadding="2" cellspacing="4">                         
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblCompName" runat="server" Font-Bold="true" CssClass="PageTitle" /></td>                        
                            </tr>
                 
                            <tr>
                                <td style="text-align:right;width:40%;">
                                    <asp:Label ID="lbStoreLocation" runat="server" Text="Store Location: " CssClass="LoginHeadings"></asp:Label></td>
                                <td style="text-align:left;width:60%;">
                                <asp:DropDownList ID="drpStoreLocations" runat="server" DataSourceID="SqlDataSource2" DataTextField="Store_Location" DataValueField="Store_Location_ID" AppendDataBoundItems="true" EnableViewState="false" >
                                    <asp:ListItem Value=""> -- select one -- </asp:ListItem>
                                    </asp:DropDownList>  
                                    
                                </td>                        
                            </tr>
                       
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label ID="lbStore_Phone1" runat="server" Text="Phone Number: " CssClass="LoginHeadings"></asp:Label></td>
                                <td style="text-align:left;">
                                    <asp:TextBox ID="txtStore_Phone1" runat="server" MaxLength="14" Width="175px"></asp:TextBox> ext. 
                                    <asp:TextBox ID="txtStore_Phone1Ext" runat="server" MaxLength="6" Width="35px"></asp:TextBox>
                                    </td>
                        
                            </tr>
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label ID="lbStore_Phone2" runat="server" Text="Secondary Phone: " CssClass="LoginHeadings"></asp:Label></td>
                                <td style="text-align:left;">
                                    <asp:TextBox ID="txtStore_Phone2" runat="server" MaxLength="14" Width="175px"></asp:TextBox> ext. 
                                    <asp:TextBox ID="txtStore_Phone2Ext" runat="server" MaxLength="6" Width="35px"></asp:TextBox>
                                    </td>
                        
                            </tr>
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label ID="lbHours_Operation" runat="server" Text="Hours of Operation: " CssClass="LoginHeadings"></asp:Label></td>
                                <td style="text-align:left;">
                                        <asp:DropDownList ID="drpHours_Operation" runat="server">
                                                <asp:ListItem>Open 24 hours</asp:ListItem>
                                                <asp:ListItem>5:00 a.m. - 9:00 p.m.</asp:ListItem>
                                                <asp:ListItem>5:00 a.m. - 10:00 p.m.</asp:ListItem>
                                                <asp:ListItem>5:00 a.m. - 10:30 p.m.</asp:ListItem>
                                                <asp:ListItem>5:00 a.m. - 11:00 p.m.</asp:ListItem>
                                                <asp:ListItem>5:30 a.m. - 9:30 p.m.</asp:ListItem>
                                                <asp:ListItem>5:30 a.m. – 11:00 p.m</asp:ListItem>
                                                <asp:ListItem>6:00 a.m. - 8:00 p.m.</asp:ListItem>
                                                <asp:ListItem>6:00 a.m. - 10:00 p.m.</asp:ListItem>
                                                <asp:ListItem>6:00 a.m. - 10:30 p.m.</asp:ListItem>
                                                <asp:ListItem>6:00 a.m. - 11:00 p.m.</asp:ListItem>
                                                <asp:ListItem>6:30 a.m. – 9:00 p.m</asp:ListItem>
                                                <asp:ListItem>6:30 a.m. - 10:00 p.m.</asp:ListItem>
                                                <asp:ListItem>6:30 a.m. - 11:00 p.m.</asp:ListItem>
                                                <asp:ListItem>7:00 a.m. - 9:00 p.m.</asp:ListItem>
                                                <asp:ListItem>7:00 a.m. - 10:00 p.m.</asp:ListItem>
                                                <asp:ListItem>7:00 a.m. - 10:30 p.m.</asp:ListItem>
                                                <asp:ListItem>7:00 a.m. - 11:00 p.m.</asp:ListItem>
                                                <asp:ListItem>8:00 a.m. - 8:00 p.m.</asp:ListItem>
                                                <asp:ListItem>8:00 a.m. - 10:00 p.m.</asp:ListItem>
                                                <asp:ListItem>8:00 a.m. - 10:30 p.m.</asp:ListItem>
                                                <asp:ListItem>8:00 a.m. - 11:00 p.m.</asp:ListItem>
                                                <asp:ListItem>9:00 a.m. - 6:00 p.m.</asp:ListItem>
                                                <asp:ListItem>9:00 a.m. - 11:00 p.m.</asp:ListItem>
                                                <asp:ListItem>10:00 a.m. - 12:00 p.m.</asp:ListItem>
                                                <asp:ListItem>12:00 p.m. - 11:00 p.m.</asp:ListItem> 
                                                <asp:ListItem>12:30 p.m. - 10:00 p.m.</asp:ListItem>
                                          </asp:DropDownList>
                                    </td>
                        
                            </tr>      
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label ID="lbSeating_Available" runat="server" Text="Seating Available: " CssClass="LoginHeadings"></asp:Label></td>
                                <td style="text-align:left;">
                                    <asp:RadioButtonList ID="ckSeating_Available" runat="server" RepeatDirection="horizontal">
                                    <asp:ListItem>YES</asp:ListItem>
                                    <asp:ListItem>NO</asp:ListItem>
                                    <asp:ListItem Selected="True">N/A</asp:ListItem>
                                    </asp:RadioButtonList>
                                    </td>
                        
                            </tr>   
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label ID="lbClosed_Renovation" runat="server" Text="Closed for Renovation: " CssClass="LoginHeadings"></asp:Label></td>
                                <td style="text-align:left;">
                                    <asp:CheckBox ID="ckClosed_Renovation" runat="server" Text="YES" />
                                    </td>
                        
                            </tr>                         
                                     
                            <tr>
                                <td align="center" colspan="2"><br /><br />
                                <asp:Button runat="server" ID="btnNewStore" Text="Add Store" OnClick="hideModalPopup_Store" />
                                   &nbsp; &nbsp;<input type="button" id="btnHideModalPopup_store" value="Cancel" /></td>
                             </tr>
                             <tr>
                                  <td colspan="2">
                                  <asp:Label  ID="lblStoreMessage" runat="server" Font-Bold="true" ForeColor="red" Text="" EnableViewState="false"  /></td>                        
                             </tr>                 
              </table>   
                            <br />
        </asp:Panel>   
       </td>
  </tr>
  </table>  
     
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DOAINT %>"
        ProviderName="<%$ ConnectionStrings:DOAINT.ProviderName %>" SelectCommand='SELECT COMPANY_ID, COMPANY_NAME FROM CMS_COMPANY ORDER BY COMPANY_NAME'>
    </asp:SqlDataSource>
    
  <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DOAINT %>" 
        ProviderName="<%$ ConnectionStrings:DOAINT.ProviderName %>" SelectCommand="SELECT STORE_LOCATION_ID, STORE_LOC_CONCOURSE || ' ' || STORE_LOCATION AS STORE_LOCATION FROM CMS_LOCATIONS ORDER BY STORE_LOC_CONCOURSE, STORE_LOCATION" />
  
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DOAINT %>"
         ProviderName="<%$ ConnectionStrings:DOAINT.ProviderName %>" SelectCommand="SELECT * FROM CMS_TYPES ORDER BY STORE_TYPE">
    </asp:SqlDataSource>
                

     <asp:ObjectDataSource ID="ObjectDataSource_Company" runat="server" SelectMethod="GetContentById" UpdateMethod="SaveNewContent" DeleteMethod="DeleteContentByID" TypeName="HJAIA2008.BusinessLogicLayer.CMS">
       <SelectParameters>
           <asp:ControlParameter ControlID="dplCompanyName" Name="contentId" PropertyName="SelectedValue"  Type="Int32" />
           <asp:Parameter DefaultValue="Concessions" Name="module_type" Type="String" />
       </SelectParameters>
       
       <UpdateParameters>
            <asp:SessionParameter Name="content" SessionField="CONTENT" Type="object" />   
       </UpdateParameters>
    
       <DeleteParameters>
           <asp:ControlParameter ControlID="dplCompanyName" Name="ID" PropertyName="SelectedValue"  Type="Int32" />
           <asp:Parameter DefaultValue="Concessions" Name="module_type" Type="String" /> 
       </DeleteParameters>       
   </asp:ObjectDataSource>
                
    <asp:ObjectDataSource ID="ObjectDataSource_Store" runat="server" SelectMethod="GetCollectionsByID"
        TypeName="HJAIA2008.BusinessLogicLayer.CMS" UpdateMethod="UpdateStoreLocation" DeleteMethod="DeleteContentByID">
        <SelectParameters>
            <asp:ControlParameter ControlID="dplCompanyName" Name="contentId" PropertyName="SelectedValue"  Type="Int32" />
            <asp:Parameter DefaultValue="Concessions_Stores" Name="module_type" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="ID" Type="Int32" />   
            <asp:Parameter Name="Store_Location_ID" Type="Int32" />   
            <asp:Parameter Name="Store_Phone1" Type ="string" DefaultValue=" " />
            <asp:Parameter Name="Store_Phone2" Type ="string" DefaultValue=" " />
            <asp:Parameter Name="Hours_Operation" Type ="string" DefaultValue=" " />
            <asp:Parameter Name="Seating_Available" Type ="string" DefaultValue="N/A" />
            <asp:Parameter Name="Closed_Renovation" Type ="string" DefaultValue="NO" />
             <asp:Parameter Name="Awarded" Type ="string" DefaultValue="NO" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />    
            <asp:Parameter DefaultValue="Concessions_Stores" Name="module_type" Type="String" />           
        </DeleteParameters>                         
    </asp:ObjectDataSource>   
    
    <asp:ObjectDataSource ID="ObjectDataSource_Files" runat="server" SelectMethod="GetCollectionsByID"
        TypeName="HJAIA2008.BusinessLogicLayer.CMS" DeleteMethod="DeleteContentByID">
        <SelectParameters>
            <asp:ControlParameter ControlID="dplCompanyName" Name="contentId" PropertyName="SelectedValue"  Type="Int32" />
            <asp:Parameter DefaultValue="Company_Files" Name="module_type" Type="String" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" /> 
            <asp:Parameter DefaultValue="Company_Files" Name="module_type" Type="String" />              
        </DeleteParameters>                         
    </asp:ObjectDataSource>
</asp:Content>

