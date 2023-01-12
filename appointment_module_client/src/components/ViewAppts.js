import React, { useEffect, useState } from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Button from "@mui/material/Button";
import Cookies from "js-cookie";
import axios from "axios";
import { getAuth, signOut } from "firebase/auth";
import {   Link } from 'react-router-dom'
function createData(name, calories, fat, carbs, protein) {
    return { name, calories, fat, carbs, protein };
  }
  
  const rows = [
    createData('Frozen yoghurt', 159, 6.0, 24, 4.0),
    createData('Ice cream sandwich', 237, 9.0, 37, 4.3),
    createData('Eclair', 262, 16.0, 24, 6.0),
    createData('Cupcake', 305, 3.7, 67, 4.3),
    createData('Gingerbread', 356, 16.0, 49, 3.9),
  ];
  
function ViewAppts() {
const [signedUser, setSignedUser] = useState(Cookies.get('userInfo') || null);
const [appointments, setAppointments] = useState([]);
const [businessName, setBusinessName] = useState(null);
const handleSignOut = () =>{
    const auth = getAuth();
    signOut(auth).then(() => {
      Cookies.remove("userInfo");
        
        window.location="/signin"
    }).catch((error) => {
      // An error happened.
    });
    
}
/**sed appointments from appointments table
 * cross apply to get fields from appointment value with business table matching with business id and json path it back.
 */
    useEffect(() =>{
        if(!signedUser){
            console.log('not signed in')
            window.location = '/signin'
        }
        else{
         
            axios.get(`https://instabookapi.azurewebsites.net/api/business_admin/${JSON.parse(signedUser).email}`)
            .then((results) =>{
                console.log(results.data)
                setAppointments(results.data[0].confirmedAppts == null ? [] : JSON.parse(results.data[0].confirmedAppts));
                console.log(appointments);
                setBusinessName(results.data[0].business_name);
            })
        }

    },[signedUser])

    return ( 
        <>
        <h1 style={{textAlign:'center'}} >{businessName == null ? 'No one\'s': businessName + "\'s"} list of appointments</h1>
        <div style={{display:'flex', justifyContent:'end'}}>
        <div  style={{textAlign:'end', marginRight:'5px'}}><Link to="/" style={{textDecoration:'none'}}><Button variant="contained">Home</Button></Link></div>
    <div  style={{textAlign:'end', marginRight:'5px'}}><Button onClick={handleSignOut} variant="contained">Sign Out</Button></div>
        </div>

        <h2 style={{textAlign:'center'}}>Admin: {JSON.parse(signedUser) ? JSON.parse(signedUser).email :'Not logged in'}</h2>
        {
            signedUser ?
         <TableContainer component={Paper}>
    {appointments.length > 0 ? 
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
            
        <TableHead>
          <TableRow>
            <TableCell>First Name</TableCell>
            <TableCell align="center">Last Name</TableCell>
            <TableCell align="center">Time</TableCell>
            <TableCell align="center">Length</TableCell>
            <TableCell align="center">Date</TableCell>
            <TableCell align="center">Service Name</TableCell>
            <TableCell align="center">Service Category</TableCell>
            <TableCell align="center">Email</TableCell>
            <TableCell align="center">Phone Number</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {appointments.map((appointment) => (
            <TableRow
              key={appointment.appt_id}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {appointment.first_name}
              </TableCell>
              <TableCell align="center">{appointment.last_name}</TableCell>
              <TableCell align="center">{appointment.start_time}</TableCell>
              <TableCell align="center">{appointment.length_minutes}</TableCell>
              <TableCell align="center">{appointment.appt_date}</TableCell>
              <TableCell align="center">{appointment.service_name}</TableCell>
              <TableCell align="center">{appointment.service_category}</TableCell>
              <TableCell align="center">{appointment.email}</TableCell>
              <TableCell align="center">{appointment.phone_number}</TableCell>
              <TableCell align="center"></TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
      : <h1>No Appointments</h1>}
    </TableContainer>:
    <h1>NO DATA</h1>
            }
        </>
     );
}

export default ViewAppts;