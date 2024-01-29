import TopicElementInfo from "../../../commonTypes/TopicElementInfo";

interface TopicContentProps {
    items: TopicElementInfo[];
    isEditable: boolean;
}

function TopicContentSection({items, isEditable}:TopicContentProps) {
    //TODO: items is temporary, topic id should be provided
    return <div>
        { items.map(item => <div>{item.innerText}</div>) }
        { isEditable && <button>+</button> }
    </div>
}

export default TopicContentSection;