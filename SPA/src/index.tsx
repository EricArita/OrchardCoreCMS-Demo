import 'bootstrap/dist/css/bootstrap.min.css';
import 'react-toastify/dist/ReactToastify.css';
import 'react-app-polyfill/ie11';
import 'core-js';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import App from './containers/App';
import "bootstrap/dist/css/bootstrap.css";
import './index.css';
import registerServiceWorker from './registerServiceWorker';
import { BrowserRouter as Router } from "react-router-dom";
import { Provider } from 'react-redux';
import store from './redux/configureStore';

ReactDOM.render(
  <Provider store={store}>
    <Router>
      <App />
    </Router>
  </Provider>,
  document.getElementById('root') // as HTMLElement
);

registerServiceWorker();
