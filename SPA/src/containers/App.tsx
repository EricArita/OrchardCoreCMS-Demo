import * as React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import CreateSubscriber from "../components/create-subscriber.component";
import EditSubscriber from "../components//edit-subscriber.component";
import ListView from "../components/list-view.component";
import ReportingData from "../components/reporting-data.component";
import AppContent from "../components/AppContent";
import Header from "../components/Header";
import logo from "../logo.svg";
import "bootstrap/dist/css/bootstrap.css";
import "./App.css";
import { AuthService } from "../services/AuthService";
import CreateRole from "../components/create-role.component";
import EditRole from "../components/edit-role.component";

class App extends React.Component {
  public authService: AuthService;

  private authUser: boolean = false;
  constructor(props: any) {
    super(props);

    this.authService = new AuthService();


  }
  public componentDidMount() {
    this.isLogedIn()
  }
  public isLogedIn = async () => {
   const auth = await this.authService.isLoggedIn();
   this.authUser = auth
    this.setState({
      authUser: auth
    });
    console.log('auth', auth);
  }
  public render() {
    return (
      <Router>
        <Header
          pageTitle="React CRUD Client with Orchard Core OIDC"
          logoSrc={logo}
          authUser={this.authUser}
        />
        <br></br>
        <div className="container-fluid">
          <div className="row">
            <div className="col">
              <AppContent />
            </div>
          </div>
        </div>
        <Container>
          <Row>
            <Col md={12}>
              <div className="wrapper">
                <Switch>
                  <Route exact path='/'  />
                  <Route path="/create-subscriber" component={CreateRole} />
                  <Route path="/edit-subscriber/:id" component={EditSubscriber} />
                  <Route path="/subscriber-list" render={() => <ListView type={'role'} />} />
                  <Route path="/edit-role/:roleName" component={EditRole} />
                  <Route path="/reporting-data" component={ReportingData} />
                </Switch>
              </div>
            </Col>
          </Row>
        </Container>        
      </Router>
    );
  }
}

export default App;
