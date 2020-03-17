import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import createAuth0Client from '@auth0/auth0-spa-js';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

const auth0 = async () => await createAuth0Client({
    domain: 'rubenruvalcaba.auth0.com',
    client_id: 'Ln803zCh6HBQxlQcFnylvuO34kIUUZZL',
    redirect_uri: 'https://localhost:44358/callback',
    audience: 'https://api.timetobuy.io'
});

auth0().then(auth => {
    ReactDOM.render(
    <BrowserRouter basename={baseUrl}>
            <App auth={auth} />
    </BrowserRouter>,
    rootElement);
})

registerServiceWorker();

