import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import EditProfile from './components/Profile/EditProfile';
import TopicLibrary from './components/TopicLibrary';
import Register from './components/Register';
import Header from './components/UI/Header';
import Profile from './components/Profile';
import LogIn from './components/LogIn';
import Home from './components/Home';
import './App.css';
import TopicView from './components/TopicView';

const arr = [
    {
        id: 1,
        name: "Programming Basics",
        subTopics: [
            {
                id: 2,
                name: "Introduction to Programming",
            },
            {
                id: 3,
                name: "Variables and Data Types",
            },
            {
                id: 4,
                name: "Control Flow (if statements, loops)",
            },
            {
                id: 5,
                name: "Functions and Methods",
            },
        ],
    },
    {
        id: 6,
        name: "Language-Specific Concepts",
        subTopics: [
            {
                id: 7,
                name: "Introduction to TypeScript/JavaScript/Python/etc.",
            },
            {
                id: 8,
                name: "Data Structures",
            },
            {
                id: 11,
                name: "Functions and Closures",
            },
        ],
    },
    {
        id: 12,
        name: "Advanced Programming Concepts",
        subTopics: [
            {
                id: 13,
                name: "Object-Oriented Programming (OOP)",
            },
            {
                id: 14,
                name: "Design Patterns",
            },
            {
                id: 15,
                name: "Error Handling and Exceptions",
            },
        ],
    },
];

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
                <Route path='/topic-library/:id' element={<TopicLibrary topics={arr} isEditable={false} />} />
                    <Route path='/topic-library/view/:id' element={<TopicView isEditable={false} topic={arr[0]} />} />
                    <Route path='/topic-library/edit/:id' element={<TopicView isEditable topic={arr[0]} />} />
                <Route path='/edit-topic-library/:id' element={<TopicLibrary topics={arr} isEditable />} />


            </Routes>
        </div>
    </Router>
    );
}