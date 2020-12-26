﻿<%@ Page Title="Positions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Positions.aspx.cs" Inherits="WebApplication.Positions.Positions" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>

        <asp:GridView runat="server" ID="PositionsGridView"
            AutoGenerateColumns="false"
            AllowPaging="true" 
            AutoGenerateDeleteButton="true"
            AutoGenerateEditButton="true" 
            OnRowCancelingEdit="PositionsGridView_RowCancelingEdit"
            OnRowDeleting="PositionsGridView_RowDeleting"
            OnRowEditing="PositionsGridView_RowEditing"
            OnRowUpdating="PositionsGridView_RowUpdating"
            PageSize="10" 
            OnPageIndexChanging="PositionsGridView_PageIndexChanging"
            Caption="Positions" 
            EmptyDataText="Empty" 
            CaptionAlign="Top" 
            PageIndex="0">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly="true" />    
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            </Columns>
        </asp:GridView>

    </div>
    
    <div style="margin-top: 10px;">
        <asp:Label ID="AddStatusLabel" runat="server" Font-Size="XX-Large" Font-Bold="true"></asp:Label>
        <h2>Add position</h2>

        <div>
            <span>Name: </span>
            <asp:TextBox ID="PositionNameTextBox" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="AddPositionButton" runat="server" Text="Add position" OnClick="AddPositionButton_Click" />
        </div>
    </div>
    
</asp:Content>