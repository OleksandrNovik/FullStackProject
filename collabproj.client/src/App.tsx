import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import EditProfile from './components/Profile/EditProfile';
import TopicLibrary from './components/TopicLibrary';
import Register from './components/Register';
import Header from './components/UI/Header';
import Profile from './components/Profile';
import LogIn from './components/LogIn';
import Home from './components/Home';
import './App.css';

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
                <Route path="/edit-profile" element={<EditProfile />} />
                <Route path="/topic-library" element={<TopicLibrary isEditable={false} />} />
            </Routes>
        </div>
    </Router>
    );
}