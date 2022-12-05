import Stepper from './components/Stepper';
function App() {
  return (
    <div className="App">
      <div style={{display:'flex',flexDirection:'column', justifyContent:'center', alignItems:'center', minHeight:'100vh'}}>
        <h1>Appointment Mod</h1>
        <Stepper/>
        </div>

    </div>
  );
}

export default App;
