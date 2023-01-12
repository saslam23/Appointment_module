import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import ViewAppts from './components/ViewAppts';
import SignIn from './components/Signin';
import reportWebVitals from './reportWebVitals';
import "./firebase/firebaseConfig";
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />
  },
  {
    path: "/appointments",
    element: <ViewAppts/>
  },
  {
    path:"/signin",
    element: <SignIn/>
  }
]);

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
<RouterProvider router={router} />
  </React.StrictMode>
);

reportWebVitals();
