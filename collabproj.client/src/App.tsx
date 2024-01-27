import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import EditProfile from './components/EditProfile/EditProfile';
import Register from './components/Register/Register';
import Header from './components/UI/Header/Header';
import Profile from './components/Profile/Profile';
import LogIn from './components/LogIn/LogIn';
import Home from './components/Home/Home';

export default function App() {

    return (
    <Router>
        <div>
            <Header />

            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/logIn" element={<LogIn />} />
                <Route path="/profile" element={<Profile />} />
                <Route path="/register" element={<Register />} />
                <Route path="/editProfile" element={<EditProfile />} />
            </Routes>
        </div>
    </Router>
    );

}