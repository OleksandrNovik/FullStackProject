import { memo } from "react";
import TopicItemContent from "./TopicItemContent";
import Topic from "../../../commonTypes/Topic";
import './TopicLibraryItem.css'
import SubTopicList from "../../SubTopicList";

interface TopicLibraryItemProps {
    // Shown topic by this list item
    topic: Topic;
    // Can user alter or delete content of this topic
    isEditable: boolean;
}
// Component to represent single item in library
// Each item can have its own subtopics, so component creates its own sub-library to show them
function TopicLibraryItem({topic, isEditable}:TopicLibraryItemProps) {
    
    return <li>
        <TopicItemContent isEditable={isEditable} title={topic.name} id={topic.id} />
        {topic.subTopics && <SubTopicList items={topic.subTopics} />}
    </li>
}

export default memo(TopicLibraryItem);