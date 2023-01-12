import React, {useState} from 'react';
import {getAuth, signInWithEmailAndPassword, GoogleAuthProvider} from "firebase/auth";
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import InputLabel from '@mui/material/InputLabel';
import Input from '@mui/material/Input';
import FormControl from '@mui/material/FormControl';
import FormHelperText from '@mui/material/FormHelperText';
import EmailIcon from '@mui/icons-material/Email';
import KeyIcon from '@mui/icons-material/Key';
import InputAdornment from "@mui/material/InputAdornment"
import axios from "axios"
import FormGroup from "@mui/material/FormGroup";
import Cookies from "js-cookie";
function Signin() {
const [email, setEmail] = useState('');
const [password, setPassword] = useState('');
    const provider = new GoogleAuthProvider();
    const auth = getAuth();
    const signInHandler =() =>{
        signInWithEmailAndPassword(auth, email, password)
        .then((userCredential) =>{
            const user = userCredential.user;
            console.log(user, 'HERE IS THE USER')
            if(user){
                Cookies.set('userInfo', JSON.stringify(user));
                window.location='/appointments'
            }
        })
        .catch((error) =>{
            const errorCode = error.code;
            const errorMessage = error.message;

            if(errorCode){
                console.log(errorMessage);
            }
        })
        // get user back if user successful, hit api with user to get business ID, in promise redirect to route with the business id as slug
    }
    return (  
        <>
         <Box className="box-style" sx={{margin:'10rem auto', maxWidth: 400, textAlign:"center"}}>
        <Card sx={{height:"500px"}} raised={true} >
      
        <CardContent sx={{ position:'relative'}}>
            <Typography color="#1976d2" variant="h4">Instabook Admin</Typography>
        <FormGroup sx={{marginTop:'3rem'}}>
            <FormControl>

  <InputLabel htmlFor="my-input">Email address</InputLabel>
  <Input
  onChange={(e) =>setEmail(e.target.value)} 
          startAdornment={
            <InputAdornment position="start">
          <EmailIcon/>
            </InputAdornment>
          } id="my-input" aria-describedby="my-helper-text" />

</FormControl>
<FormControl sx={{marginTop:'1rem', marginBottom:'1rem'}}>
<InputLabel htmlFor="my-input">Password</InputLabel>
  <Input onChange={(e) =>setPassword(e.target.value)}  startAdornment={
            <InputAdornment position="start">
          <KeyIcon/>
            </InputAdornment>
          } id="my-input" aria-describedby="my-helper-text" type="password" />
</FormControl>
<Button onClick={signInHandler} variant="contained">Sign In</Button>
</FormGroup>
        </CardContent>
        </Card>
        </Box>
        </>
    );
}

export default Signin;