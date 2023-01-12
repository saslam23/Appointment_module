import Stepper from './components/Stepper';
import Button from '@mui/material/Button';
import {   Link } from 'react-router-dom'
function App() {
  return (
    <div className="App">
       <div style={{textAlign:'end', margin:'2rem'}} ><Link to="/appointments" style={{textDecoration:'none'}}><Button variant="contained">Admin</Button></Link></div>
      <div style={{display:'flex',flexDirection:'column', justifyContent:'start', alignItems:'center'}}>
        <h1>Appointment Module</h1>
        <Stepper/>
 
      
        </div>

    </div>
  );
}

export default App;
