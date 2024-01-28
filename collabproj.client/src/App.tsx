import './App.css';
import TopicLibrary from './components/TopicLibrary';

function App() {
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
    return <div>
        <TopicLibrary topics={arr} isEditable={true} />
        <button>Save</button>
    </div>
}

export default App;