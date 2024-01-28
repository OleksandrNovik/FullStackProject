import { memo, useState } from "react";
import TopicLibrary from "..";
import Topic from "../../../commonTypes/Topic";
import TopicItemContent from "./TopicItemContent";

interface TopicLibraryItemProps {
    // Shown topic by this list item
    topic: Topic;
    // Can user alter or delete content of this topic
    isEditable: boolean;
}
// Component to represent single item in library
// Each item can have its own subtopics, so component creates its own sub-library to show them
function TopicLibraryItem({topic, isEditable}:TopicLibraryItemProps) {
    // Using state we can make it easier to edit subtopics for a given list item
    const [editSubTopics, setEditSubTopics] = useState(false);
    // We add edit children button only if topic has subtopics in it
    // Edit button toggle changes whether we edit the current topic or its subtopics
    const editSubTopicsButton = () => {
        return topic.subTopics && <button onClick={() => setEditSubTopics(prev => !prev)}>ed</button>
    }
    
    return <li>
        <TopicItemContent isEditable={isEditable && !editSubTopics} title={topic.name} editSubTopics={editSubTopicsButton} />
        <TopicLibrary topics={topic.subTopics} isEditable={editSubTopics}/>
    </li>
}

export default memo(TopicLibraryItem);