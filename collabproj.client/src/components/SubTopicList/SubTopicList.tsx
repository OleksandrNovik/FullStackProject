import { Link } from "react-router-dom";
import Topic from "../../commonTypes/Topic";

interface SubTopicListProps {
    // Subtopics that will be displayed
    items:Topic[];
}
// List of subtopics to handle references to a specific place in a topic
function SubTopicList({items}:SubTopicListProps) {
    return <ul>
        {
            ///TODO: link subtopic to a specific place in topic
            items.map(item => 
                <li key={item.id}>
                    <Link to={"/"}> {item.name} </Link>
                </li>
        )}
    </ul>
}

export default SubTopicList;