import "./App.css"
import { useState } from 'react'
import List from "./components/List"
import WeekPicker from './components/WeekPicker'

function App() {

  const [date, setDate] = useState(null)

  return (
    <div className="App">
      <div className="logo"/>
      <WeekPicker onChanged={setDate}/>
      <List date={date}/>
    </div>
  );
}

export default App;
