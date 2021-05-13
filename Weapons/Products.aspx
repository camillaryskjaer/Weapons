<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products</title>


    <link rel="icon" type="image/x-icon" href="assets/img/favicon.ico" />
    <!-- Font Awesome icons (free version)-->
    <script src="https://use.fontawesome.com/releases/v5.15.1/js/all.js" crossorigin="anonymous"></script>
    <!-- Google fonts-->
    <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700" rel="stylesheet" type="text/css" />
    <!-- Core theme CSS (includes Bootstrap)-->
    <link href="css/st.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
       <div class="container">


         <main role="main">

      <section class="jumbotron text-center">
        <div class="container">
          <h1 class="jumbotron-heading">Album example</h1>
          <p class="lead text-muted">Something short and leading about the collection below—its contents, the creator, etc. Make it short and sweet, but not too short so folks don't simply skip over it entirely.</p>
          <p>
            <a href="#" class="btn btn-primary my-2">Main call to action</a>
            <a href="#" class="btn btn-secondary my-2">Secondary action</a>
          </p>
        </div>
      </section>

      <div class="album py-5 bg-light">
        <div class="container">

          <div class="row">
        <asp:Repeater ID="Repeater1" runat="server">
       
        <ItemTemplate>
                 <div class="col-md-4">
              <div class="card mb-4 box-shadow">
                <img class="card-img-top" src="assets/img/<%# Eval("Img")%>" alt="Card image cap">
                <div class="card-body">
                  <p class="card-text"> '<%# Eval("Name")%></p>
                  <div class="d-flex justify-content-between align-items-center">
                  
                    <small class="text-muted"><%# Eval("Desc")%></small>
                  </div>
                </div>
              </div>
            </div>
        
        </ItemTemplate>
     
    </asp:Repeater>
    
          </div>
        </div>
      </div>

    </main>




    </form>
</body>
</html>
